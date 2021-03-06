﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using Plugin.Jobs;

namespace Xamarin.Droid
{
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
        : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            CrossCurrentActivity.Current.Init(this);
            CrossJobs.Init(this);
            base.OnCreate();            
        }
    }
}