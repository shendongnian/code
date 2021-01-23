        private byte[] ConvertInkCanvasToByteArray()
        {
            //First, we need to get all of the strokes in the canvas
            var canvasStrokes = myCanvas.InkPresenter.StrokeContainer.GetStrokes();
            //Just as a check, make sure to only do work if there are actually strokes (ie not empty)
            if (canvasStrokes.Count > 0)
            {
                var width = (int)myCanvas.ActualWidth;
                var height = (int)myCanvas.ActualHeight;
                var device = CanvasDevice.GetSharedDevice();
                //Create a new renderTarget with the same width and height as myCanvas at 96dpi
                var renderTarget = new CanvasRenderTarget(device, width,
                    height, 96);
                using (var ds = renderTarget.CreateDrawingSession())
                {
                    //This will clear the renderTarget with a clean slate of a white background.
                    ds.Clear(Windows.UI.Colors.White);
                    //Here is where we actually take the strokes from the canvas and draw them on the render target.
                    ds.DrawInk(myCanvas.InkPresenter.StrokeContainer.GetStrokes());
                }
                //Finally, this will return the render target as a byte array.
                return renderTarget.GetPixelBytes();
            }
            else
            {
                return null;
            }
        }
