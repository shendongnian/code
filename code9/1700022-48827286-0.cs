        private delegate void UpdateVisibilityDelegate(Visibility visibility);
        private void UpdateVisiblity(Visibility visibility)
        {
            //LoadingAdorner.Visibility = visibility;
            //loaderBorder.Visibility = visibility;
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Your Action() code here
            // Change the visibility using this method
            Dispatcher.CurrentDispatcher.BeginInvoke(new UpdateVisibilityDelegate(this.UpdateVisiblity), Visibility.Visible);
        }
