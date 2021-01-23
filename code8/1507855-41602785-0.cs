        public static Bitmap GaussianFilter(Bitmap image)
        {
            float[] conv_matrix =
            { 1.0f/8.0f, 1.0f/4.0f, 1.0f/8.0f,
              1.0f/4.0f, 1.0f/2.0f, 1.0f/4.0f,
              1.0f/8.0f, 1.0f/4.0f, 1.0f/8.0f };
            return createBitmap_convolve(image, conv_matrix);
        }
        public static Bitmap createBitmap_convolve(Bitmap src, float[] coefficients)
        {
            //Fast method using android solution: ScriptIntrinsicConvolve3x3()
            Bitmap result = Bitmap.CreateBitmap(src.Width,
              src.Height, src.GetConfig());
            RenderScript renderScript = RenderScript.Create(Android.App.Application.Context);
            Allocation input = Allocation.CreateFromBitmap(renderScript, src);
            Allocation output = Allocation.CreateFromBitmap(renderScript, result);
            ScriptIntrinsicConvolve3x3 convolution = ScriptIntrinsicConvolve3x3
              .Create(renderScript, Element.U8_4(renderScript));
            convolution.SetInput(input);
            convolution.SetCoefficients(coefficients);
            convolution.ForEach(output);
            output.CopyTo(result);
            renderScript.Destroy();
            return result;
        }
