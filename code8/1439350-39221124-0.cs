        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "Successfully ordered";
            obj.Interval = new TimeSpan(0, 0, 2);
            obj.Start();
            obj.Tick += Obj_Tick;
        }
        private void Obj_Tick(object sender, EventArgs e)
        {
            textBox.Text = "Place your chip";
            obj.Stop();
        }
