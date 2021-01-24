        TileSet ts = null;
    
        if(tmxMap.Tilesets.TryGetValue(k, out ts)
        {
           for (int l = 0; l < ts.Tiles.Count; l++)
           { 
              Tiles tl = null;
    
              if(ts.TryGetValue(l,out tl)
              {
                if (tl.Properties != null)
                {
                  for (int m = 0; m < tl.Properties.Count; m++)
                  {
                   //Do something
                  }
                }
              }
            }
         }
