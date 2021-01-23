    if (list.Count > 1)
            {
                double average = list.Average();
                textBox2.Text = average.ToString();
                rotorSpeed.Stop();
            }
