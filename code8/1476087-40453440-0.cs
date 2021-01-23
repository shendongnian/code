                TimeSpan var1 = TimeSpan.FromMinutes(Convert.ToDouble(textBox1.Text));
                TimeSpan var2 = TimeSpan.FromMinutes(Convert.ToDouble(textBox2.Text));
                double overtime = (var1.TotalMinutes * var2.TotalMinutes)/60;
                
                textBox3.Text = overtime +" "+ "$" .ToString();
