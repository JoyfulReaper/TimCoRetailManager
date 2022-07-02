using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SaleController : ControllerBase
{
    private readonly ISaleData _saleData;

    public SaleController(ISaleData saleData)
    {
        _saleData = saleData;
    }

    [HttpPost]
    [Authorize(Roles = "Cashier")]
    public void Post(SaleModel sale)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // old way - RequestContext.Principal.Identity.GetUserId();

        _saleData.SaveSale(sale, userId);
    }

    [HttpGet]
    [Route("GetSalesReport")]
    [Authorize(Roles = "Admin,Manager")]
    public List<SaleReportModel> GetSalesReport()
    {
        return _saleData.GetSaleReport();
    }
}
