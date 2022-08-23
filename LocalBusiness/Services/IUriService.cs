using LocalBusiness.Filter;
using System;

namespace LocalBusiness.Services
{
  public interface IUriService
  {
    public Uri GetPageUri(PaginationFilter filter, string route);
  }
}