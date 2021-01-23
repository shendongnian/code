	public class CustomButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer, 
		ViewTreeObserver.IOnDrawListener, ViewTreeObserver.IOnPreDrawListener
	{
		public bool OnPreDraw() // IOnPreDrawListener
		{
			System.Console.WriteLine("A View is *about* to be Drawn");
			return true;
		}
		public void OnDraw() // IOnDrawListener
		{
			System.Console.WriteLine("A View is really *about* to be Drawn");
		}
		public override void Draw(Android.Graphics.Canvas canvas)
		{
			base.Draw(canvas);
			System.Console.WriteLine("A View was Drawn");
		}
		protected override void Dispose(bool disposing)
		{
			Control?.ViewTreeObserver.RemoveOnDrawListener(this);
			Control?.ViewTreeObserver.RemoveOnPreDrawListener(this);
			base.Dispose(disposing);
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{			
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{
				Control?.SetWillNotDraw(false); // force the OnPreDraw to be called :-(
				Control?.ViewTreeObserver.AddOnDrawListener(this); // API16+
				Control?.ViewTreeObserver.AddOnPreDrawListener(this); // API16+
				System.Console.WriteLine($"{Control?.ViewTreeObserver.IsAlive}");
			}
		}
	}
