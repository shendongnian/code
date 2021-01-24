    using System;
    using Android.Content;
    using Android.Content.Res;
    using Android.Graphics;
    using Android.Support.V4.Content;
    using Android.Support.V4.Graphics.Drawable;
    using Android.Support.V7.Widget;
    using Android.Util;
    using Android.Widget;
    namespace Example.Droid.App.Views
    {
	    public class IconView : AppCompatImageView
	    {
		    private ColorStateList tint;
		    private Context context;
		    public IconView(Context context) :base(context)
		{
			Initialize(context, null, 0);
		}
		public IconView(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			Initialize(context, attrs, 0);
		}
		public IconView(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
			Initialize(context, attrs, defStyle);
		}
		void Initialize(Context mContext, IAttributeSet attrs, int defStyle)
		{
			context = mContext;
			TypedArray a = context.ObtainStyledAttributes(attrs, Resource.Styleable.IconView, defStyle, 0);
			tint = a.GetColorStateList(Resource.Styleable.IconView_iconTint);
			a.Recycle();
		}
		protected override void DrawableStateChanged()
		{
			base.DrawableStateChanged();
			if (tint != null && tint.IsStateful)
				UpdateTintColor();
		}
       private void UpdateTintColor()
		{
			var color = new Color(tint.GetColorForState(GetDrawableState(), new Color(0)));
			SetColorFilter(color);
		}
		public void SetColorFilter(ColorStateList tint)
		{
			this.tint = tint;
			base.SetColorFilter(new Color(tint.GetColorForState(GetDrawableState(), new Color(0))));
		}
	   }
    }
