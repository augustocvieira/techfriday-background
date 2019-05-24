using Android.App;
using Android.Content;

namespace Xamarin.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted})]
    public class BootBroadcast : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //MainActivity.ScheduleServiceWork(context);
        }
    }
}