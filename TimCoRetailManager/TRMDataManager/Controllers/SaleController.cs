using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;
using TRMDataManager.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();


            data.SaveSale(sale, userId);
        }

        [HttpGet]
        [Route("GetSalesReport")]
        [Authorize(Roles = "Admin,Manager")]
        public List<SaleReportModel> GetSalesReport()
        {
            if(RequestContext.Principal.IsInRole("Admin"))
            {
                // Do admin Stuff
            }
            else if (RequestContext.Principal.IsInRole("Manager"))
            {
                // Do manager Stuff
            }

            SaleData data = new SaleData();
            return data.GetSaleReport();
        }
    }
}
