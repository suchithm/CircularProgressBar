using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace CircularProgressBar
{
	[Activity (Label = "CircularProgressBar", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private InitCircularProgressClass mRateTextCircularProgressBar;
 
//		Handler handler =new Handler();
//		Runnable runnable=new Runnable() {
//			@Override
//			public void run() {
//				FnUpdateProgress();
//			}
//		};


		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		 
			SetContentView (Resource.Layout.Main);

		 
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				 
			};
		}
		private int secondUpdate=0;
		public  void FnUpdateProgress()
		{
			//handler.postDelayed( runnable,1500 );
			secondUpdate++;
			if(secondUpdate <= 60){
				mRateTextCircularProgressBar.setProgress(secondUpdate);
			}
			else if(secondUpdate == 61){
				mRateTextCircularProgressBar.ClearAnimation();
				mRateTextCircularProgressBar=null;
				mRateTextCircularProgressBar = (InitCircularProgressClass)FindViewById(Resource.Id.rate_progress_bar);
				secondUpdate=1;
				mRateTextCircularProgressBar.setProgress(secondUpdate);
			}
		}
	}
}


