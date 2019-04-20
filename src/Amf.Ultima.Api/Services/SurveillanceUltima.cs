using System;
using System.Threading;
using System.Threading.Tasks;
using Amf.Ultima.Api.DataStorage;
using Amf.Ultima.Api.HubConfig;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace Amf.Ultima.Api.Services
{
    public class SurveillanceUltima : IHostedService, IDisposable
    {
        private readonly IHubContext<UltimaHub> _hub;
        private TimerUltima _service;

        public SurveillanceUltima(IHubContext<UltimaHub> hub)
        {
            _hub = hub;
        }

        public void Dispose()
        {
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _service = new TimerUltima(() => {
                _hub.Clients.All.SendAsync("panier-ultima-erreur", DataManager.GetData());
            });
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}