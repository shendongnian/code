                var form = new RenderForm(World.WindowTitle);
        form.ClientSize = new Size(World.WindowWidth, World.WindowHeight);
        var device = new Device(new Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters()
        {
            BackBufferWidth = form.ClientSize.Width,
            BackBufferHeight = form.ClientSize.Height
        });
        //Some stuff here, irrelevant to DirectX
        MessagePump.Run(form, () =>
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
            device.BeginScene();
            sprite.Begin(SlimDX.Direct3D9.SpriteFlags.AlphaBlend);
            //Stuff here
            sprite.End();
            device.EndScene();
            device.Present();
            stopwatch.Stop();
            int ms = 16 - (int)(stopwatch.ElapsedMilliseconds);
            if (ms > 0)
            {
                Thread.Sleep(ms);
            }
        });
