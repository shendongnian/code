    private void pic_Zones_MouseClick(object sender, MouseEventArgs e)
            {
                int SelectedZoneID = ZoneClickedRS(e.X, e.Y,1);
                if (SelectedZoneID == NOT_IN_ZONE)
                    return;
                string sZone = tZones[SelectedZoneID].sZoneDesc;
                miSelectedZoneID = tZones[SelectedZoneID].nZoneID; //Defined elsewhere
                
               // For Testing: 
               //MessageBox.Show("The selected Zone:" + sZone, "Selected Zone", MessageBoxButtons.OK);
            }
