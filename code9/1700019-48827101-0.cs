    BackgroundWorker worker = new BackgroundWorker { WorkerSupportsCancellation = true };
            worker.DoWork += delegate(object sender1, DoWorkEventArgs e1)
            {
                CurrentDispatcher.Invoke(
                                     new Action(() =>
                                     {
                                         if (!string.IsNullOrEmpty(txt_Comment.Text))
                                         {
                                             LoadingAdorner.Visibility = Visibility.Visible;
                                             loaderBorder.Visibility = Visibility.Visible;                                         
                                         }
                                     }),
                                     DispatcherPriority.Normal);
    								 
    								 using (Entities DB = new Entities(settings.LinqConnection))
                                             {
                                                 if (txt_Comment.Text.Length > 1000)
                                                 {//In this case loading image is visible
    
                                                     MessageBox.Show("Comment is too large.", "Alert !", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                     return;
                                                 }
    
                                                 var comment = DB.Table1.Create();//Here loading image is not visible.
                                                 comment.value = txt_Comment.Text;
                                                 comment.Date = DateTime.Now;
                                                 comment.ModifiedBy = settings.CurrentUID;
                                                 DB.Table1.Add(comment);
    
                                                 DB.SaveChanges();
                                             }
            };
