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
using Xamarin.Essentials;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.LocalNotifications;

[assembly: Dependency (typeof(Xamarin.Droid.BackgroundScheduler_Android))]
namespace Xamarin.Droid
{
    public class BackgroundScheduler_Android : IBackgroundScheduler
    {
        private long _interval;
        private readonly string _apiKey = "PhlNNVrhYhmshFPcTwUjl5jvkTEup1JYM5ejsnmTFoGZhU8DLk";
        public void ScheduleBackground(long interval)
        {
            _interval = interval;
            ScheduleServiceWork(CrossCurrentActivity.Current.AppContext);
            //SchedulePluginJob();
        }

        private void ScheduleServiceWork(Context context)
        {
            var alarmIntent = new Intent(context.ApplicationContext, typeof(AlarmReceiver));
            var broadcast = PendingIntent.GetBroadcast(context.ApplicationContext, 0, alarmIntent, PendingIntentFlags.NoCreate);
            if (broadcast == null)
            {
                var pendingIntent = PendingIntent.GetBroadcast(context.ApplicationContext, 0, alarmIntent, 0);
                var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
                alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime(), _interval, pendingIntent);
            }
        }

        private async void SchedulePluginJob()
        {
            var job = new JobInfo()
            {
                Name = "BackgroundAPIJob",
                Type = typeof(BackgroundAPIJob),
                RequiredNetwork = NetworkType.Any,
                Repeat = true
            };

            await CrossJobs.Current.Schedule(job);
        }        
    }
}