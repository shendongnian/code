	public class CustomRenderer : ButtonRenderer
	{
		public override void Draw(CGRect rect)
		{
			base.Draw(rect);
			Console.WriteLine("A UIView is finished w/ drawRect: via msg/selector)");
		}
    }
