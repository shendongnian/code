        private void Submit_Btn_Click(object sender, RoutedEventArgs e)
        {
            var controlAsUserControl1 = MainContentControl.Content as UserControl1;
            if (controlAsUserControl1 != null)
            {
                Debug.WriteLine(controlAsUserControl1.TxtBox1.Text);
            }
        }
