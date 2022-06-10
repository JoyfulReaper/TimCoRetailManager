﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Cashier")]
    public void Post(SaleModel sale)
    {
        SaleData data = new SaleData();
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // old way - RequestContext.Principal.Identity.GetUserId();

        data.SaveSale(sale, userId);
    }

    [HttpGet]
    [Route("GetSalesReport")]
    [Authorize(Roles = "Admin,Manager")]
    public List<SaleReportModel> GetSalesReport()
    {
        SaleData data = new SaleData();
        return data.GetSaleReport();
    }
}
