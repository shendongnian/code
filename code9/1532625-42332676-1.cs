            try
            {
                 double weight = 0;
                double height = 0;
                Double.TryParse("1.555", out weight);
                Double.TryParse("1.555", out height);
                if (weight > 300 || weight < 10 || height > 2.2 || height < 0.2)
                {
                    MessageBox.Show("Not a valid input.");
                }
                // round to two didgets
                double result = Math.Round(1.5254, 2);
                // convert result to string
                string resultString = Convert.ToString(result);
            }
            catch
            {
                MessageBox.Show("Not a valid input.");
            }
