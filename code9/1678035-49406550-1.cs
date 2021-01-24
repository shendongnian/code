    public void LoadClickableZone()
            {
                //this can now be loaded into table and pulled from dataset into class if so desired
                //Use Test Colour for visibility sbPaintbrush=Color.Bisque and Transparent for functionality
                System.Drawing.Color sbPCol = Color.Cornsilk;
                //System.Drawing.Color sbPCol = Color.Transparent;
    
                try
                {
    
                tZones.Add(new clsClickableZones() { nZoneID = 1, sZoneCode = "R1", sZoneDesc = "Zone 1", sbPaintbrush = sbPCol, nZoneX = 160, nZoneY = 30, nZonewidth = 25, nZoneheight = 20 });
                tZones.Add(new clsClickableZones() { nZoneID = 2, sZoneCode = "R2", sZoneDesc = "Zone 2", sbPaintbrush = sbPCol, nZoneX = 184, nZoneY = 55, nZonewidth = 12, nZoneheight = 12 });
                tZones.Add(new clsClickableZones() { nZoneID = 3, sZoneCode = "R3a", sZoneDesc = "Zone 3", sbPaintbrush = sbPCol, nZoneX = 160, nZoneY = 58, nZonewidth = 12, nZoneheight = 12 });
                tZones.Add(new clsClickableZones() { nZoneID = 63, sZoneCode = "R3b", sZoneDesc = "Zone 4", sbPaintbrush = sbPCol, nZoneX = 177, nZoneY = 68, nZonewidth = 12, nZoneheight = 12 });
                tZones.Add(new clsClickableZones() { nZoneID = 4, sZoneCode = "R4", sZoneDesc = "Zone 5", sbPaintbrush = sbPCol, nZoneX = 160, nZoneY = 90, nZonewidth = 25, nZoneheight = 15 });
                tZones.Add(new clsClickableZones() { nZoneID = 5, sZoneCode = "R5", sZoneDesc = "Zone 6", sbPaintbrush = sbPCol, nZoneX = 160, nZoneY = 115, nZonewidth = 15, nZoneheight = 10 });
                tZones.Add(new clsClickableZones() { nZoneID = 6, sZoneCode = "R6", sZoneDesc = "Zone 7", sbPaintbrush = sbPCol, nZoneX = 147, nZoneY = 80, nZonewidth = 10, nZoneheight = 10 });
                tZones.Add(new clsClickableZones() { nZoneID = 7, sZoneCode = "R7", sZoneDesc = "Zone 8", sbPaintbrush = sbPCol, nZoneX = 186, nZoneY = 135, nZonewidth = 12, nZoneheight = 20 });
                tZones.Add(new clsClickableZones() { nZoneID = 8, sZoneCode = "R8", sZoneDesc = "Zone 9", sbPaintbrush = sbPCol, nZoneX = 170, nZoneY = 145, nZonewidth = 20, nZoneheight = 30 });
                tZones.Add(new clsClickableZones() { nZoneID = 9, sZoneCode = "R9", sZoneDesc = "Zone 10", sbPaintbrush = sbPCol, nZoneX = 151, nZoneY = 180, nZonewidth = 33, nZoneheight = 20 });
    
    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading Zones", MessageBoxButtons.OK);
                }
    }
