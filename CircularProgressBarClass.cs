using System;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Util;

namespace CircularProgressBar
{
	public class CircularProgressBarClass : View
	{
		
	  int mDuration = 100;
	  int mProgress = 30;
	  Paint mPaint = new Paint();
	  RectF mRectF = new RectF();
	  int mBackgroundColor = Color.White;
	  int mPrimaryColor = Color.Yellow; 
	  float mStrokeWidth = 10F;

		public interface IOnProgressChangeListener {

			  void onChange(int duration, int progress, float rate);
		}
		public IOnProgressChangeListener mOnChangeListener;

		public void setOnProgressChangeListener(IOnProgressChangeListener l)
		{
			mOnChangeListener = l;
		}
		public CircularProgressBarClass(Context context) :base(context) {
		 ;
		}
		public CircularProgressBarClass(Context context, IAttributeSet attrs) : base(context,attrs) {
			;//super(context, attrs);
		}

		public void setMax( int max ) {
			if( max < 0 ) {
				max = 0;
			}
			mDuration = max;
		}

		public int getMax() {
			return mDuration;
		}

		public void setProgress( int progress ) {
			if( progress > mDuration ) {
				progress = mDuration;
			}
			mProgress = progress;
			if( mOnChangeListener != null ) {
				mOnChangeListener.onChange(mDuration, progress, getRateOfProgress());
			}
			Invalidate();
		}

		public int getProgress() {
			return mProgress;
		}

		public void setBackgroundColor( int color ) {
			mBackgroundColor = color;
		}

		public void setPrimaryColor( int color ) {
			mPrimaryColor = color;
		}

		public void setCircleWidth(float width) {
			mStrokeWidth = width;
		}

		protected override void OnDraw (Canvas canvas)
		{
			base.OnDraw (canvas);
			int halfWidth = Width / 2;
			int halfHeight = Height/2;
			int radius = halfWidth < halfHeight ? halfWidth : halfHeight;
			float halfStrokeWidth = mStrokeWidth / 2;

			//mPaint.Color=mBackgroundColor;
			mPaint.Dither=true;
			mPaint.Flags = PaintFlags.AntiAlias; 
			mPaint.AntiAlias=true;
			mPaint.StrokeWidth=mStrokeWidth;
			mPaint.SetStyle(Paint.Style.Stroke);
			canvas.DrawCircle(halfWidth, halfHeight, radius - halfStrokeWidth, mPaint);

			//mPaint.Color=mPrimaryColor;
			mRectF.Top = halfHeight - radius + halfStrokeWidth;
			mRectF.Bottom = halfHeight + radius - halfStrokeWidth;
			mRectF.Left = halfWidth - radius + halfStrokeWidth;
			mRectF.Right = halfWidth + radius - halfStrokeWidth;
			canvas.DrawArc(mRectF, -90, getRateOfProgress() * 360, false, mPaint);
			canvas.Save();
		} 

		private float getRateOfProgress() {
			return (float)mProgress / mDuration;
		}
	}
}

