    public void LoadTreatmentZone_RSole()
            {
                //this can now be loaded into table and pulled from dataset into class if so desired
                //Use Test Colour for visibility sbPaintbrush=Color.Bisque and Transparent for functionality
                System.Drawing.Color sbPCol = Color.Cornsilk;
                //System.Drawing.Color sbPCol = Color.Transparent;
    
                try
                {
                    string sSQL = "SELECT pkID, TreatmentAreaCode, TreatmentAreaDesc, ZoneX, ZoneY, ZoneH, ZoneW FROM myDB.lkMyZones ; ";
                    Datafeed cData = new Datafeed();
                    DataSet dsData = new DataSet();
                    cData.GetDataset(sSQL, ref dsData);
                    cData = null;
    
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsData.Tables[0].Rows)
                        {
                            tZones.Add(new clsClickablesZones()
                            {
                                nZoneID = Convert.ToInt32(row["pkID"].ToString()),
                                sZoneCode = row["TreatmentAreaCode"].ToString(),
                                sZoneDesc = row["TreatmentAreaDesc"].ToString(),
                                sbPaintbrush = sbPCol,
                                nZoneX = Convert.ToInt32(row["ZoneX"].ToString()),
                                nZoneY = Convert.ToInt32(row["ZoneY"].ToString()),
                                nZonewidth = Convert.ToInt32(row["ZoneW"].ToString()),
                                nZoneheight = Convert.ToInt32(row["ZoneH"].ToString())
                            });
                        }
                    }
    
                    dsData = null;
    
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading Treatment Zones - R Sole", MessageBoxButtons.OK);
                }
    }
