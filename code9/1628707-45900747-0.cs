        private void AverageAndDisplay()
        {
            try
            {
                //Convert values to numeric
                decimal one = Convert.ToDecimal(textBox1.Text);
                decimal two = Convert.ToDecimal(textBox2.Text);
                decimal three = Convert.ToDecimal(textBox3.Text);
                decimal four = Convert.ToDecimal(textBox4.Text);
                //Find the average
                decimal average = (one + two + three + four) / 4.0m;
                //Show the average, after formatting the number as a two decimal string representation
                textBox5.Text = string.Format("{0:0.00}", average);
            }
            catch(Exception e) //Converting to a number from a string can causes errors
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
