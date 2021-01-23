    using (BitmapRenderer bitmapRender = new BitmapRenderer(blendeffect))
    {
              bitmapRender.RenderOptions = RenderOptions.Cpu;
              Bitmap bitmap = await bitmapRender.RenderAsync();
    }
