using System;

using Android.App;
using Android.Content.PM;
//using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Android.Content;
using Xamarin.Essentials;
using Android.Runtime;

namespace Xamarin.Droid
{
    [Activity(Label = "Xamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            var x = ApplicationContext;
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //public static void ScheduleServiceWork(Context context)
        //{
        //    var alarmIntent = new Intent(context.ApplicationContext, typeof(AlarmReceiver));
        //    var broadcast = PendingIntent.GetBroadcast(context.ApplicationContext, 0, alarmIntent, PendingIntentFlags.NoCreate);
        //    if (broadcast == null)
        //    {
        //        var pendingIntent = PendingIntent.GetBroadcast(context.ApplicationContext, 0, alarmIntent, 0);
        //        var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
        //        alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime(), 15000, pendingIntent);
        //    }
        //}
    }
}