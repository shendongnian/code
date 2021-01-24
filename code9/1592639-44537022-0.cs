    if (dsImages.Tables[0].Rows.Count > 0)
                {
                    var filelists = dsImages.Tables[0].Rows[0]["image_url"].ToString().Split(',').ToList();
                    List<string[]> imagelist = new List<string[]>();
                    List<string[]> videolist = new List<string[]>();
                    if (filelists.Count >= 0)
                    {
                        for (int i = 0; i < filelists.Count; i++)
                        {
                            string FileName = filelists[i].ToString();
                            string Extension = Path.GetExtension(FileName);
                            if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".jpeg" || Extension == ".JPEG" ||
                               Extension == ".gif" || Extension == ".GIF" || Extension == ".png" || Extension == ".PNG" ||
                               Extension == ".tiff" || Extension == ".TIFF" || Extension == ".bmp" || Extension == ".BMP")
                            {
                                imagelist.Add(new string[] { filelists[i].ToString() });
                            }
                            else
                            {
                                videolist.Add(new string[] { filelists[i].ToString() });
                            }
                        }
                        DataTable dtImages = ConvertListToDataTable(imagelist);
                        DLImages.DataSource = dtImages;
                        DLImages.DataBind();
                        DataTable dtVideo = ConvertListToDataTable(videolist);
                        DLVideos.DataSource = dtVideo;
                        DLVideos.DataBind();
                                              
                    }                    
                }
                else
                {
                }
    static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();
            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }
            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }
            return table;
        }
