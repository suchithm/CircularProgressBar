using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Android.Graphics;

namespace CircularProgressBar
{
	[Activity (Label = "CircularProgressBar", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		InitCircularProgressClass initCircularProgressBar;  

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
 
			SetContentView (Resource.Layout.Main);
 
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {  
				
				fnInitializeCircleBar();

				var timer = new System.Timers.Timer();
				timer.Interval = 1000; 
				timer.Elapsed += OnTimedEvent;
				timer.Enabled = true; 
			}; 
		}
		void fnInitializeCircleBar()
		{
			initCircularProgressBar = (InitCircularProgressClass)FindViewById(Resource.Id.rate_progress_bar);
			initCircularProgressBar.setMax(60);
			initCircularProgressBar.ClearAnimation(); 
			initCircularProgressBar.setTextSize (24);
			initCircularProgressBar.setTextColor (Color.Blue);
			initCircularProgressBar.setTextTypeFaceBold ();

			initCircularProgressBar.getCircularProgressBar().setCircleWidth(20);
			initCircularProgressBar.getCircularProgressBar().setMax(60);
			initCircularProgressBar.getCircularProgressBar().setPrimaryColor(Color.Blue);
			initCircularProgressBar.getCircularProgressBar().setBackgroundColor(Color.White);  
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


