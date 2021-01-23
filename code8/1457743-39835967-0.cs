    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(()=>
    {
       Bitmap image = new Bitmap(System.Windows.Forms.Clipboard.GetImage());
       image.Save(ImagePath + Path.GetFileNameWithoutExtension(file) + ".svg");
    }
