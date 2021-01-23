    AppDomain.CurrentDomain.FirstChanceException += new EventHandler<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>(CurrentDomain_FirstChanceException);
        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
                Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("Error Occurred \n\r" + e.Exception.Message + "\n\r" + e.Exception.StackTrace, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error)));
        }
