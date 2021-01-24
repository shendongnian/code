     private void Start(bool add)
        {
         
            DoMath math = new DoMath();
            decimal? number1 = math.Validate(textBox1.Text);
            decimal? number2 = math.Validate(textBox2.Text);
            decimal? number3 = math.Validate(textBox3.Text);
            decimal? number4 = math.Validate(textBox4.Text);
            decimal? number5 = math.Validate(comboBox1.SelectedItem.ToString());
           
            if (number1 != null &&
                number2 != null &&
                 number3 != null &&
                number4 != null)
            {
                label1.Text = math.Caulculate(number1.Value, number2.Value, number3.Value, number4.Value, add, number5.Value).ToString();
            }
            else
            {
                label1.Text = "There is validation error in texbox(es)";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Start(true);
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            Start(false);
        }
