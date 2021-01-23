     protected override void DoResize(uint width, uint height)
        {
            if (width == 0 || height == 0)
                return;
            base.DoResize(width, height); //Here i was calling base.Resize (which was deprecated after a change in the application architecture)
            _camera.Width = width;
            _camera.Height = height;
            _svgTexture.Dispose();
            _svgRenderView.Dispose();
            CreateRenderToTexture(_viewReference);
            ResizePending = false;
        }
