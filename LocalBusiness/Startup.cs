using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using LocalBusiness.Models;
using LocalBusiness.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using LocalBusiness.Services;


namespace LocalBusiness
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("https://localhost:5001", "http://localhost:5000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            
            services.AddDbContext<LocalBusinessContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            
            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
            services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();
            
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "LocalBusiness", 
                    Version = "v1",
                    Description = "An ASP.NET Core Web API for local business",
                    Contact = new OpenApiContact
                    {
                        Name = "Zhibin Liang",
                        Email = "ifthereisoneday@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/zhibin-liang"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "No license requied"
                    }
                });               
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => 
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LocalBusiness v1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
