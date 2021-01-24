        DialogProgress dialogProgress = null;
        private void ShowProgressBar()
        {
            dialogProgress = new DialogProgress("ATAM Desktop", "Loading module...");
            dialogProgress.Show();
        }
        private void LoadProgressBar(Thread thread)
        {
            lock (lockProcessStart)
            {
                if (dialogProgress == null)
                {
                    LayoutRoot.Opacity = 0.9;
                    LayoutRoot.Refresh();
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
            }
        }
        private void UnloadProgressBar(Thread thread, bool isSave = false)
        {
            lock (lockProcessStart)
            {
                if (dialogProgress != null)
                    Dispatcher.FromThread(thread).Invoke(new Action(() => dialogProgress.Close()));
                dialogProgress = null;
                if (isSave)
                    LayoutRoot.Opacity = 1;
            }
        }
