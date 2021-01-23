	public class TextSwitcherFactory : Java.Lang.Object, ViewSwitcher.IViewFactory
	{
		public View MakeView()
		{
			TextView t = new TextView(Latest.this);
			t.setGravity(Gravity.TOP | Gravity.CENTER_HORIZONTAL);
			t.setTextSize(36);
			return t;
		}
	}
