        public  virtual void SetFrame(Uri anotherUserControll, string FrameElementName)
         {
                            var mainFrame =(Frame)Application.Current.MainWindow.FindName("MainFrame");
                            var userControll = mainFrame.Content as UserControl;
                            var frame = userControll.FindName(contentControll) as Frame;
                            if (frame != null)
                             {
                                frame.Source = anotherUserControll;
                             }           
         }
