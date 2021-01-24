     Point eLoc = listView1.PointToClient(Control.MousePosition);
     var ColumnIndex = -1;
     if (listView1.Items.Count == 0)
     {
          getHeaders(listView1);
          for (int i = 0; i < lvHeaderBounds.Count; i++)
               if (lvHeaderBounds[i].X + lvHeaderBounds[i].Width > eLoc.X)
               {
                    ColumnIndex =  i;
                    break;
               }
     }
            else...
