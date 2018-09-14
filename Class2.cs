using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace ConsoleApplication1.Modules
{
    internal static class Class2
    {
        private static Timer loopingTimer;

        internal static Task StartTimer()
        {
            loopingTimer = new Timer()
            {
                Interval = 5000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTicked;
            return Task.Run(() =>
            {
                // i'm just here to simulate hard work
            });
        }

        private static async void OnTimerTicked(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}