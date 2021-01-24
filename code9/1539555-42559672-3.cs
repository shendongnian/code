        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (ASMTask != null)
            {
                await ForceUpdate();
            }
        }
