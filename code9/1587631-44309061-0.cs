    internal Task<Bitmap> RenderAsync(
                     ImageData data, CancellationToken cancellationToken)
       {
           return Task.Run(() =>
           {
               var bmp = new Bitmap(data.Width, data.Height);
               for(int y=0; y<data.Height; y++)
               {
                   cancellationToken.ThrowIfCancellationRequested();
                   for(int x=0; x<data.Width; x++)
                   {
                       // render pixel [x,y] into bmp
                   }
               }
               return bmp;
           }, cancellationToken);
       }
