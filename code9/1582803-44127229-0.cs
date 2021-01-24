        IDataObject data;
                    Image bmap;
                    //---copy the image to the Clipboard---
                    SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0);
                    //---retrieve the image from Clipboard and convert it
                    // to the bitmap format---
                    data = Clipboard.GetDataObject();
                    if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
                    {
                        bmap =
                            ((Image)(data.GetData(typeof(
                                System.Drawing.Bitmap))));
                       
                        if (!Directory.Exists("Your Directory that u wanna to save pic on it!"))
                        {
                            Directory.CreateDirectory("Directory path");
                        }
                        bmap.Save("The Directory u wanna to save and the filename", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
