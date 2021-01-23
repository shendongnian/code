        private async void button1_Click(object sender, EventArgs e)
        {
            int repeat = 5;
            int amount;
            if (Int32.TryParse(textBox1.Text, out amount)) // <--| go on only if textBox1 input value can be cast into an integer
                for (int i = 0; i <= repeat; i++)
                {                
                    await Connection.SendToServerAsync(2700, amount); // <--| use the "amount" integer value read from textBox1
                    await Connection.SendToServerAsync(3745);
                }
        }
