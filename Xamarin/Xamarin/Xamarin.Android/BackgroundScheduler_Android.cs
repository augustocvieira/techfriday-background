using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System;
using Plugin.CurrentActivity;
using Plugin.Jobs;

[assembly: Dependency (typeof(Xamarin.Droid.BackgroundScheduler_Android))]
namespace Xamarin.Droid
{
    public class BackgroundScheduler_Android : IBackgroundScheduler
    {
        public async Task ScheduleBackground()
        {
            var job = new JobInfo()
            {
                Name = "Back",
                Type = typeof(BackgroundAPIJob),
                BatteryNotLow = true,
                RequiredNetwork = NetworkType.WiFi,                
                Repeat = true
            };

            CrossJobs.Current.Schedule(job);
        }
    }
}