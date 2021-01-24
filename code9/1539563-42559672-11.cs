        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (ASMTask != null)
            {
                try
                {
                    await ForceUpdate();
                }
                catch (Exception exc)
                {
                    Debug.Write(exc.Message);
                    ASMTask = Start();
                    await ASMTask;
                }
            }
        }
