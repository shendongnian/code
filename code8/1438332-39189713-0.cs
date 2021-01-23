        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var dto = new Dto();
            window2 win2 = new window2();
            win2.Dto = dto;
            win2.ShowDialog();
            textBox1.Text = dto.Text;
        }
