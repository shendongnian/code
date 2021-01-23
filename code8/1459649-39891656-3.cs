       Window1 window = new Window1();
            //window.Content = uc;
            var aa = window.Content as Grid;
            foreach (var e in aa.Children)
            {
                if (e is Frame)
                {
                    Frame f = e as Frame;
                    f.ContentRendered += F_ContentRendered;
                }
            }
    //only inside of handler of ContentRendered event you can access to the content of your Frame:
      private void F_ContentRendered(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            UserControl1 uc1 = frame.Content as UserControl1;
            MainViewModel mvm = uc1.DataContext as MainViewModel;
        }
        
    
