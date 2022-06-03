using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _events;
        private readonly SalesViewModel _salesVM;

        public ShellViewModel(IEventAggregator events,
            SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;
            
            _events.SubscribeOnPublishedThread(this);

            Task.Run(async () =>
            {
                await ActivateItemAsync(IoC.Get<LoginViewModel>());
            });
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM);
        }
    }
}
