        private void img_recieve(object sender)
        {
            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                     {
                         items.Add(new Img { Img_In = (BitmapImage)sender });
                     }));
            }
            catch (Exception e)
            {
                messageerreur(e);
            }
        }
