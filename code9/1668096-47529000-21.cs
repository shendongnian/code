    using System.Drawing;
    using System.Drawing.Imaging;
    var bwInverted_mx = new float[][]
    {
        new float[] {  -1,   -1,   -1,  0, 0},
        new float[] {  -1,   -1,   -1,  0, 0}, 
        new float[] {  -1,   -1,   -1,  0, 0}, 
        new float[] {   0,    0,    0,  1, 0},
        new float[] { 1.5f, 1.5f, 1.5f, 0, 1}  //Adjusted: to combine with threshold
    };
    var bw_mx = new float[][]
    {
        new float[] { 1,  1,  1, 0, 0},
        new float[] { 1,  1,  1, 0, 0}, 
        new float[] { 1,  1,  1, 0, 0}, 
        new float[] { 0,  0,  0, 1, 0},
        new float[] {-1, -1, -1, 0, 1}
    };
    using (Graphics gr = Graphics.FromImage(img))
    using (ImageAttributes attributes = new ImageAttributes())
    {
      // Adjust the threshold as needed
      float threshold = 0.2f;
      //attributes.SetColorMatrix(new ColorMatrix(bw_mx));
      attributes.SetColorMatrix(new ColorMatrix(bwInverted_mx));
      attributes.SetThreshold(threshold);
      Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
      gr.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attributes);
    }
