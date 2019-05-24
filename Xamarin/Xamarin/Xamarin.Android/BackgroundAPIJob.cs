using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Jobs;
using System.Net.Http;
using Newtonsoft.Json;

namespace Xamarin.Droid
{
    [Service(Name = "com.companyname.Xamarin.BackgroundAPIJob",
        Permission = "android.permission.BIND_JOB_SERVICE")]
    public class BackgroundAPIJob : IJob
    {
        
        public async Task Run(Plugin.Jobs.JobInfo jobInfo, CancellationToken cancelToken)
        {
            
            
            
        }
    }


}