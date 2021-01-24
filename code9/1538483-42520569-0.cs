    else if (radioButton2.Checked == true)
                {
                    alarme[count] = DateTime.Now
                                    .AddHours(Convert.ToDouble(textBox1.Text))
                                    .AddMinutes(Convert.ToDouble(textBox2.Text));
                }
