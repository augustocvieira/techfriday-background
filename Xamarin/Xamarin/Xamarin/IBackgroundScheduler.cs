using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin
{
    public interface IBackgroundScheduler
    {
        void ScheduleBackground(long interval);
    }
}
