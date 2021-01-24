    else if (arg1 == "/p")
                {
                    if (e.Args[1] == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid or missing window handle.");
                        System.Windows.Application.Current.Shutdown();
                    }
                    IntPtr previewHandle = new IntPtr(long.Parse(e.Args[1]));
                    pw = new previewForm(previewHandle);
                    GetImages();
                    pw.Show();
                }
