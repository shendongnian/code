                //Save chart as image
                w = 1;
                foreach (var ws in exBook.Worksheets)
                {
                    var chartObjects = (Excel.ChartObjects)(ws.ChartObjects(Type.Missing));
                    foreach (var co in chartObjects)
                    {
                        int retry = 0;
                        bool successfulSave = false;
                        while (!successfulSave && retry < 10) // retry by incerementing w parameter 10 times)
                        {
                           successfulSave = SaveExcelChartAsPNG(exportPath, @"\leaf" + w + ".png"))
                           retry++;
                           w++;
                        }
                        
                        if (!successfulSave)
                        {
                            // Try again with random filename, otherwise exit
                            string filename = Path.GetRandomFileName();
                            if (!SaveExcelChartAsPNG(exportPath, filename))
                            {
                                // Save still not successful, exit
                                Application.Exit();
                            }
                        }
                    }
                }
