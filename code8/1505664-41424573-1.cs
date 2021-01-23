                    public   System.Drawing.Size GetTotalArea()
                        {
                       System.Drawing.Size SizeYouNeed = new Size(0,0);
                        foreach (var screen in Screen.AllScreens)
                       {
                        SizeYouNeed.Height+=screen.WorkingArea.Height;
                         SizeYouNeed.Width +=screen.WorkingArea.Width;
               
                            }
                             return SizeYouNeed;
                              }
