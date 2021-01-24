        private void App_StateChanged(object sender, StateChangedEventArgs e)
        {
            if(e.State == ApplicationState.Defective)
            {
                //Show window on error !
                ShowMainWindow();
                //(sender as Window).Activate();
            }
            _notifyIcon.Icon = DrawIcon(e.StateBrush);
            MainWindow.Icon = Imaging.CreateBitmapSourceFromHIcon(_notifyIcon.Icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _notifyIcon.Visible = true;
        }
