using System;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Graphics;
using Android.Util;
using Android.App;


namespace CircularProgressBar
{
	public class InitCircularProgressClass :FrameLayout,CircularProgressBarClass.IOnProgressChangeListener
	{
		CircularProgressBarClass mCircularProgressBar;
		TextView mRateText;
		Context _activity;
		public InitCircularProgressClass(Context context):base(context) {
			  _activity=context;
			init();
		}
		public InitCircularProgressClass(Context context, IAttributeSet attrs) :base(context,attrs){
			//super(context, attrs);
			init();
		}
		private void init() {
			mCircularProgressBar = new CircularProgressBarClass(_activity);
			this.AddView(mCircularProgressBar);
			LayoutParams lp = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
			lp.Gravity = GravityFlags.Center;
			mCircularProgressBar.LayoutParameters=(lp);
			mRateText = new TextView(_activity);
			this.AddView(mRateText);
			mRateText.LayoutParameters=lp;
			mRateText.Gravity=GravityFlags.Center;
			mRateText.SetTextColor( Color.Black);
			mRateText.SetTextSize( ComplexUnitType.Dip,10);
			mCircularProgressBar.setOnProgressChangeListener(this);
		}
		public void setMax( int max ) {
			mCircularProgressBar.setMax(max);
		}

		public void setProgress(int progress) {
			mCircularProgressBar.setProgress(progress);
		}

		public CircularProgressBarClass getCircularProgressBar() {
			return mCircularProgressBar;
		}

		public void setTextSize(float size) {
			mRateText.SetTextSize(ComplexUnitType.Dip,size);
		}

		public void setTextColor( int color) {
			mRateText.SetTextColor(_activity.Resources.GetColor(color));
		}
		protected override void OnLayout (bool changed, int left, int top, int right, int bottom)
		{
			base.OnLayout (changed, left, top, right, bottom);
		}

		public void onChange(int duration, int progress, float rate)
		{
			
			mRateText.SetText( (int) (rate * 90 ));
		}
	
		 	 
 //		@Override
//		public void onChange(int duration, int progress, float rate) {
//			//mRateText.setText(String.valueOf( 90 - ((int)(rate * 90 )) ));
//			mRateText.setText(String.valueOf( ((int)(rate * 90 )) ));
//		}
	}
}

