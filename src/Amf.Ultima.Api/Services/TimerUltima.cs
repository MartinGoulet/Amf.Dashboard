using System;
using System.Threading;

namespace Amf.Ultima.Api.Services
{
    public class TimerUltima
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; set; }

        public TimerUltima(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Executer, _autoResetEvent, 1000, 2000);
        }

        public void Executer(object stateInfo) 
        {
            _action();

            // Arrêter après 60 sec
            if((DateTime.Now -TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}