            oXL.ScreenUpdating = false;
            oRng = oSheet.get_Range("A1").Resize[c.GetLongLength(0),1];
            for(long x=1; x<=c.GetLongLength(0); x++)
            {
                oRng.Cells.Item[x, 1] = c[x - 1];
            }
            oXL.ScreenUpdating = true;
