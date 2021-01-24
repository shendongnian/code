        private void Setup()
        {
            cameraView = FindViewById<SurfaceView>(Resource.Id.camera_view);
            //need to wait for view to inflate to get size
            isSetup = false;
            ViewTreeObserver vto = cameraView.ViewTreeObserver;
            vto.GlobalLayout += Vto_GlobalLayout;
        }
        void Vto_GlobalLayout(object sender, System.EventArgs e)
        {
            //this didn't work either
            //ViewTreeObserver vto = cameraView.ViewTreeObserver;
            //vto.GlobalLayout -= Vto_GlobalLayout;
            ViewTreeObserver vto = (ViewTreeObserver)sender;
            if (vto.IsAlive)
                vto.GlobalLayout -= Vto_GlobalLayout; //even after removing it seems to continue to fire...
            if (!isSetup)
            {
                isSetup = true;
                DoYourCodeNow();
            }
        }
