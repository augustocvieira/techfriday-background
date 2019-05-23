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
        private readonly string apiKey = "4dc1aebaa63721f0f8e79a55e2514bc7";
        public async Task Run(Plugin.Jobs.JobInfo jobInfo, CancellationToken cancelToken)
        {
            string term = "background";
            var url = $"https://mashape-community-urban-dictionary.p.rapidapi.com/define?term=" + term;
            List<APIResponse> results;

            using (var httpClient = new HttpClient())
            {
                var uri = new Uri(url);
                httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "mashape-community-urban-dictionary.p.rapidapi.com");
                httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
                var response = await httpClient.GetStringAsync(uri);
                results = JsonConvert.DeserializeObject<List<APIResponse>>(response);
            }

            foreach (var result in results)
            {
                //
            }
            
            
        }
    }


}