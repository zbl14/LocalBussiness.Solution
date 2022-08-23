using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalBusiness.Models;
using System.Linq;
using LocalBusiness.Wrappers;
using LocalBusiness.Filter;

namespace LocalBusiness.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BusinessesController : ControllerBase
  {
    private readonly LocalBusinessContext _db;

    public BusinessesController(LocalBusinessContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaginationFilter filter, string name, string type, string phone, string address)
    {
      IQueryable<Business> query = _db.Business.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }

      if (phone != null)
      {
        query = query.Where(entry => entry.Phone == phone);
      }

      if (address != null)
      {
        query = query.Where(entry => entry.Address == address);
      }
             
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);  
      var pagedData = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      
      var totalRecords = await _db.Business.CountAsync();
      
      var response = new PagedResponse<List<Business>>(pagedData, validFilter.PageNumber, validFilter.PageSize);

      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Business>> GetBusiness(int id)
    {
      var business = await _db.Business.FindAsync(id);

      if (business == null)
      {
        return NotFound();
      }

      return Ok(new Response<Business>(business));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Business business)
    {
      if (id != business.BusinessId)
      {
        return BadRequest();
      }

      _db.Entry(business).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BusinessExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Business>> Post(Business business)
    {
      _db.Business.Add(business);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId }, business);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
      var business = await _db.Business.FindAsync(id);
      if (business == null)
      {
        return NotFound();
      }

      _db.Business.Remove(business);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool BusinessExists(int id)
    {
      return _db.Business.Any(e => e.BusinessId == id);
    }
  }
}