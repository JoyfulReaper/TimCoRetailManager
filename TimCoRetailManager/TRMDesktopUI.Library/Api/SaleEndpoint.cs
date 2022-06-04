using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class SaleEndpoint : ISaleEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public SaleEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage resposne = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Sale", sale))
            {
                if (resposne.IsSuccessStatusCode)
                {
                    // Log succesful call?
                }
                else
                {
                    throw new Exception(resposne.ReasonPhrase);
                }
            }
        }
    }
}
