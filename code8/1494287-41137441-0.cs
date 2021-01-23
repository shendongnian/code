    private byte[] ConvertInkCanvasToByteArray()
    {
        var canvasStrokes = SignatureCanvas.InkPresenter.StrokeContainer.GetStrokes();
        if (canvasStrokes.Count > 0)
        {
            var width = (int)SignatureCanvas.ActualWidth;
            var height = (int)SignatureCanvas.ActualHeight;
            var device = CanvasDevice.GetSharedDevice();
            device.DeviceLost += DeviceOnDeviceLost;
            var renderTarget = new CanvasRenderTarget(device, width, height, 96);
            using (var ds = renderTarget.CreateDrawingSession())
            {
                ds.Clear(Windows.UI.Colors.White);
                ds.DrawInk(SignatureCanvas.InkPresenter.StrokeContainer.GetStrokes());
            }
            return renderTarget.GetPixelBytes();
        }
        else
        {
            return null;
        }
    }
    
    private void DeviceOnDeviceLost(CanvasDevice sender, object args)
    {
        Debug.WriteLine("DeviceOnDeviceLost");
    }
