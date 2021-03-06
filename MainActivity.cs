﻿using Android.App;
using Android.OS;
using Android.Graphics;

namespace CircularProgressBar
{
	[Activity (Label = "QuickQuiz", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		InitCircularProgressClass initCircularProgressBar;  

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.Main); 
			fnInitializeCircleBar();
			fnStartTimer(); 
		}
		void fnInitializeCircleBar()
		{
			initCircularProgressBar = (InitCircularProgressClass)FindViewById(Resource.Id.rate_progress_bar);
			initCircularProgressBar.setMax(60);
			initCircularProgressBar.ClearAnimation(); 
			initCircularProgressBar.setTextSize (24);
			initCircularProgressBar.setTextColor (Color.ParseColor("#0D85EC"));
			initCircularProgressBar.setTextTypeFaceBold ();
			initCircularProgressBar.setProgress(0);

			initCircularProgressBar.getCircularProgressBar().setCircleWidth(20);
			initCircularProgressBar.getCircularProgressBar().setMax(60);
			initCircularProgressBar.getCircularProgressBar().setPrimaryColor(Color.ParseColor("#0D85EC")); ;
			initCircularProgressBar.getCircularProgressBar().setBackgroundColor(Color.ParseColor("#83C6FF"));  
		}
		void fnStartTimer()
		{ 
			var timer = new System.Timers.Timer();
			timer.Interval = 1000;
			timer.Elapsed += OnTimedEvent;
			timer.Enabled = true;
		}
		void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
		{
			RunOnUiThread (FnUpdateProgress); 
		}

		int secondUpdate=0;
		public  void FnUpdateProgress()
		{ 
			secondUpdate++;
			if(secondUpdate <= 60){
				initCircularProgressBar.setProgress(secondUpdate);
			}
			else if(secondUpdate == 61){
				initCircularProgressBar.ClearAnimation();
				initCircularProgressBar=null;
				initCircularProgressBar = (InitCircularProgressClass)FindViewById(Resource.Id.rate_progress_bar);
				secondUpdate=1;
				initCircularProgressBar.setProgress(secondUpdate);
			}
		}
	}
}


