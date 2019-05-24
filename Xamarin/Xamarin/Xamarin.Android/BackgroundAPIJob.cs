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
using Xamarin.Essentials;
using Plugin.LocalNotifications;
using Android.Util;

namespace Xamarin.Droid
{
    [Service(Name = "com.companyname.Xamarin.BackgroundAPIJob",
        Permission = "android.permission.BIND_JOB_SERVICE")]
    public class BackgroundAPIJob : IJob
    {
        private readonly string _apiKey = "PhlNNVrhYhmshFPcTwUjl5jvkTEup1JYM5ejsnmTFoGZhU8DLk";
        public async Task Run(Plugin.Jobs.JobInfo jobInfo, CancellationToken cancelToken)
        {

            string response = string.Empty;
            try
            {
                var currentConnectivity = Connectivity.NetworkAccess;
                var networkProfiles = Connectivity.ConnectionProfiles;
                if (currentConnectivity == NetworkAccess.Internet && networkProfiles.Contains(ConnectionProfile.WiFi))
                {
                    string term = "background";
                    var url = $"https://mashape-community-urban-dictionary.p.rapidapi.com/define?term=" + term;
                    APIResponseRoot results;

                    using (var httpClient = new HttpClient())
                    {
                        var uri = new Uri(url);
                        httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "mashape-community-urban-dictionary.p.rapidapi.com");
                        httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
                        response = await httpClient.GetStringAsync(uri);
                        results = JsonConvert.DeserializeObject<APIResponseRoot>(response);
                    }

                    CrossLocalNotifications.Current.Show("Objetos recebidos", $"{results.list.Count} objetos recebidos da API");
                }

                else
                {
                    CrossLocalNotifications.Current.Show("Conectividade", $"Habilite o WiFi para realizar as tarefas em Background.");
                }

            }
            catch (Exception ex)
            {
                Log.WriteLine(LogPriority.Error, "[Job Log Error]", ex.Message);
            }
            finally
            {
                Log.WriteLine(LogPriority.Error, "[Job Log]", response);
            }



        }
    }


}