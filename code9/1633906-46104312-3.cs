    [DllImport("ImageProcessor")]
    static extern IntPtr LensFlare(PtrInt bitmap, int x, int y, double Brightness);
    
    [DllImport("gdi32.dll")]
    static extern bool DeleteObject(IntPtr hObject);
    
    private void button1_Click(object sender, EventArgs e)
    {
    	Bitmap b = new Bitmap(@"d:\a.bmp");
    	IntPtr hbmp = LensFlare(b.GetHbitmap(), 100, 100, 50);
    	try {
   			pictureBox1.Image = Image.FromHbitmap(hbmp);
    	}
   		finally {
   			DeleteObject(hbmp);
   		}
    }
