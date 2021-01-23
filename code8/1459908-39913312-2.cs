    private double getDPIScale()
        {
            PresentationSource source = PresentationSource.FromVisual(this);
            double dpiX , dpiY;
            if (source != null)
            {
                dpiX = 96.0 * source.CompositionTarget.TransformToDevice.M11;
                dpiY = 96.0 * source.CompositionTarget.TransformToDevice.M22;
                return dpiX / 96.0;
            }
            return 0;            
        }
