	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			test();
		}
		System.Timers.Timer fade = new System.Timers.Timer(50);
		System.Timers.Timer fade2 = new System.Timers.Timer(50);
		Image originalImage = Image.FromFile(@"D:\kevin\Pictures\odds&Sods\kitchener.jpg");
		int alpha = 100;
		void test()
		{
			fade.Elapsed +=new System.Timers.ElapsedEventHandler(fade_Tick);
			fade2.Elapsed+=new System.Timers.ElapsedEventHandler(fade_Tick_Two);
			fade.Start();
		}
		delegate void timerDelegate(object sender, EventArgs e);
		private void fade_Tick(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new timerDelegate(fade_Tick), sender, e);
				return;
			}
			if (alpha >= 0)
			{
				picboxPic.Image =  SetImgOpacity(originalImage, alphaToOpacity(alpha));
				picboxPic.Invalidate();
				alpha--;
			}
			if (alpha < 0)
			{
				alpha = 0;
				fade.Stop();
				fade2.Start();
			}
		}
		private void fade_Tick_Two(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new timerDelegate(fade_Tick_Two), sender, e);
				return;
			}
			if (alpha <= 100)
			{
				picboxPic.Image = SetImgOpacity(originalImage, alphaToOpacity(alpha));
				picboxPic.Invalidate();
				alpha++;
			}
			if (alpha > 100)
			{
				alpha = 100;
				fade2.Stop();
				fade.Start();
			}
		}
		float alphaToOpacity(int alpha)
		{
			if (alpha == 0)
				return 0.0f;
			return (float)alpha / 100.0f;
		}
		//Setting the opacity of the image
		public static Image SetImgOpacity(Image imgPic, float imgOpac)
		{
			Bitmap bmpPic = new Bitmap(imgPic.Width, imgPic.Height);
			Graphics gfxPic = Graphics.FromImage(bmpPic);
			ColorMatrix cmxPic = new ColorMatrix();
			cmxPic.Matrix33 = imgOpac;
			ImageAttributes iaPic = new ImageAttributes();
			iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			gfxPic.DrawImage(imgPic, new Rectangle(0, 0, bmpPic.Width, bmpPic.Height), 0, 0, imgPic.Width, imgPic.Height, GraphicsUnit.Pixel, iaPic);
			gfxPic.Dispose();
			return bmpPic;
		}
	}
