            /// <summary>
        /// Proportionally resize listview columns when listview size changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onLV_FileList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if ((sender is ListView) && 
                (e.PreviousSize.Width > 0))
            {
                double total_width = 0;
                GridViewColumnCollection gvcc = ((GridView)(sender as ListView).View).Columns;
                foreach (GridViewColumn gvc in gvcc)
                {
                    gvc.Width = (gvc.Width / e.PreviousSize.Width) * e.NewSize.Width;
                    total_width += gvc.Width;
                }
                //Increase width of last column to fit width of listview if integer division made the total width to small
                if (total_width < e.NewSize.Width)
                {
                    gvcc[gvcc.Count - 1].Width += (e.NewSize.Width - total_width);
                }
                //Render changes to ListView before checking for horizontal scrollbar
                this.AllowUIToUpdate();
                //Decrease width of last column to eliminate scrollbar if it is displayed now
                ScrollViewer svFileList = this.FindVisualChild<ScrollViewer>(LV_FileList);
                while ((svFileList.ComputedHorizontalScrollBarVisibility != Visibility.Collapsed) &&  (gvcc[gvcc.Count - 1].Width > 1))
                {
                    gvcc[gvcc.Count - 1].Width--;
                    this.AllowUIToUpdate();
                }
            }
        }
        /// <summary>
        /// Threaded invocation to handle updating UI in resize loop
        /// </summary>
        private void AllowUIToUpdate()
        {
            DispatcherFrame dFrame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Render, new DispatcherOperationCallback(delegate(object parameter)
            {
                dFrame.Continue = false;
                return null;
            }), null);
            Dispatcher.PushFrame(dFrame);
        }
