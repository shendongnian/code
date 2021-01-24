        gMapControl.OnMapZoomChanged += GMapControl_OnMapZoomChanged;
        private void GMapControl_OnMapZoomChanged()
        {
            if (gMapControl.Zoom > 10)
            {
                // split markers
            }
            else
            {
                // group markers
            }
        }
        
