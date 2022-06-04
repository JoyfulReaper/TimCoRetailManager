using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Library.Api;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IApiHelper _apiHelper;
        private readonly IEventAggregator _events;
        
        private string _userName = "admin@.com";
        private string _password = "Password123!";
        private string _errorMessage;

        public LoginViewModel(IApiHelper apiHelper, 
            IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }
        
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        
        public bool IsErrorVisible
        {
            get {
                return ErrorMessage?.Length > 0;
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { 
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool CanLogin
        {
            get
            {
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    return true;
                }

                return false;
            }
        }
        
        public async Task Login()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);

                // Capture more information about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                await _events.PublishOnUIThreadAsync(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
