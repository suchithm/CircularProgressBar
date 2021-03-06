﻿using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Graphics;
using Android.Util;

namespace CircularProgressBar
{
	public class InitCircularProgressClass :FrameLayout,CircularProgressBarClass.IOnProgressChangeListener
	{
		CircularProgressBarClass mCircularProgressBar;
		TextView mRateText; 
		int maxValue;
		public InitCircularProgressClass(Context context):base(context) { 
			init();
		}
		public InitCircularProgressClass(Context context, IAttributeSet attrs) :base(context,attrs){ 
			init();
		}
		void init() {
			mCircularProgressBar = new CircularProgressBarClass( Context);
			AddView(mCircularProgressBar);
			var lp = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			lp.Gravity = GravityFlags.Center;
			mCircularProgressBar.LayoutParameters=lp;
			mRateText = new TextView(Context);
			AddView(mRateText);
			mRateText.LayoutParameters=lp;
			mRateText.Gravity=GravityFlags.Center;  
			mCircularProgressBar.setOnProgressChangeListener(this);
		}
		public void setMax( int max ) {
			mCircularProgressBar.setMax(max);
			maxValue = max;
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

		public void setTextColor( Color color) {
			mRateText.SetTextColor(color); 
		} 

		public void setTextTypeFaceBold()
		{
			mRateText.Typeface = Typeface.DefaultBold;
		}
			
		public void onChange(int duration, int progress, float rate)
		{ 
			mRateText.Text=( (int) (rate * maxValue )).ToString();    
		}
 
	}
}

