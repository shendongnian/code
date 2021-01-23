    	public class MyButton : Button
	{
		public MyButton()
		{
			
		}
		
		public override bool AutoSize {
			get {
				return false;
			}
			set {
				base.AutoSize = false;
			}
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
						
			Font = new Font(this.Font.FontFamily,Height-10,this.Font.Style,GraphicsUnit.Pixel);
			
		}
	}
