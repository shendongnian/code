        private void button1_Click(object sender, EventArgs e)
        { 
            var number = Double.Parse(textBox1.Text);
            if (number <= numbera)
            {
                label1.Text = ("Customer can receive  £5 off purchase");
            }
            else if (number <= numberb)
            {
                label1.Text = ("Customer can receive  £10 off purchase");
            }
        }
