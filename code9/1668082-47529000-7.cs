    using System.Drawing;
    using System.Drawing.Imaging;
      var BW_Inverted_matrix = new float[][]
      {
         new float[] { -1f,  -1f,  -1f, 0, 0},
         new float[] { -1f,  -1f,  -1f, 0, 0}, 
         new float[] { -1f,  -1f,  -1f, 0, 0}, 
         new float[] {  0,    0,    0,  1, 0},
         new float[] {1.7f, 1.7f, 1.7f, 0, 1}	//Setting this value above 1, inverts black and white
      };
      var BW_matrix = new float[][]
      {
         new float[] { 1.5f,  1.5f,  1.5f, 0, 0},
         new float[] { 1.5f,  1.5f,  1.5f, 0, 0}, 
         new float[] { 1.5f,  1.5f,  1.5f, 0, 0}, 
         new float[] {   0,     0,     0,  1, 0},
         new float[] {-1.5f, -1.5f, -1.5f, 0, 1}
      };
    if (_img != null)
    {
       using (Graphics gr = Graphics.FromImage(_img))
       {
          // Adjust the threshold as needed
          float _threshold = 0.124f;
          ImageAttributes _ImageAttributes = new ImageAttributes();
          _ImageAttributes.SetColorMatrix(new ColorMatrix(BW_Inverted_matrix));
          _ImageAttributes.SetThreshold(_threshold);
          var _rect = new Rectangle(0, 0, _img.Width, _img.Height);
          gr.DrawImage(_img, _rect, 0, 0, _img.Width, _img.Height, GraphicsUnit.Pixel, _ImageAttributes);
