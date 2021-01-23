    if (gMapVisor.Overlays.Count > 0)
    {
         for (int i = 0; i < gMapVisor.Overlays[0].Markers.Count; i++)
         {
              Bitmap iconoNavegacion;
              Random r = new Random();
                    
              float angle = (float)(360 * r.NextDouble());
              iconoNavegacion = RotateImage(Properties.Resources.StatusUpdate_32x, angle);
              GMarkerGoogle chincheta = new GMarkerGoogle(gMapVisor.Overlays[0].Markers[i].Position, iconoNavegacion);
              gMapVisor.Overlays[0].Markers[i] = chincheta;
          }
    }
