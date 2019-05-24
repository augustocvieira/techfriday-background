using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Jobs;
using Plugin.CurrentActivity;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Android.Util;
using Plugin.LocalNotifications;
using Plugin.Connectivity;
using Xamarin.Essentials;

namespace Xamarin.Droid
{
    [Service]
    public class PeriodicBackgroundService : Service
    {
        private const string Tag = "[PeriodicBackgroundService]";

        private bool _isRunning;
        private Context _context;
        private Task _task;
        private readonly string _apiKey = "PhlNNVrhYhmshFPcTwUjl5jvkTEup1JYM5ejsnmTFoGZhU8DLk";

        #region Overrides

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            _context = this;
            _isRunning = false;
            _task = new Task(DoWork);
        }
        
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _task.Start();
            }

            return StartCommandResult.Sticky;
        }

        #endregion

        private async void DoWork()
        {
            try
            {
                var currentConnectivity = Connectivity.NetworkAccess;
                var networkProfiles = Connectivity.ConnectionProfiles;
                if ((currentConnectivity == NetworkAccess.Internet) && (networkProfiles.Contains(ConnectionProfile.WiFi)))
                {
                    string term = "background";
                    var url = $"https://mashape-community-urban-dictionary.p.rapidapi.com/define?term=" + term;
                    APIResponseRoot results;

                    using (var httpClient = new HttpClient())
                    {
                        var uri = new Uri(url);
                        httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "mashape-community-urban-dictionary.p.rapidapi.com");
                        httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
                        var response = await httpClient.GetStringAsync(uri);
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
                Log.WriteLine(LogPriority.Error, Tag, ex.Message);
            }
            finally
            {
                StopSelf();
            }
        }
    }
}