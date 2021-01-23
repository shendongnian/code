       private async void button1_Click(object sender, EventArgs e)
        {
            int repeat = 5;
            for (int i = 0; i <= repeat; i++)
            {                
                await Connection.SendToServerAsync(2700, Int32.Parse(textBox1.Text); // <--|use the integer value to which textBox1 value can be cast to
                await Connection.SendToServerAsync(3745);
            }
        }
