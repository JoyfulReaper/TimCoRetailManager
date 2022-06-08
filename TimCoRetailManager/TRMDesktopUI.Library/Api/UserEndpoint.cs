using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class UserEndpoint : IUserEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public UserEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<UserModel>> GetAll()
        {
            using (HttpResponseMessage respose = await _apiHelper.ApiClient.GetAsync("/api/User/Admin/GetAllUsers"))
            {
                if (respose.IsSuccessStatusCode)
                {
                    var result = await respose.Content.ReadAsAsync<List<UserModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(respose.ReasonPhrase);
                }
            }

        }
    }
}
