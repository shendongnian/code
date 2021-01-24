            int heroT1Might = 100;
            int chest20 = 20;
            int chest50 = 50;
            if (string.IsNullOrWhiteSpace(textBox20.Text) || string.IsNullOrWhiteSpace(textBox50.Text))
            {
                // At least one is empty
                return;
            }
            
            if(!int.TryParse(textBox20.Text) || !int.TryParse(textBox50.Text))
            {
                // At least one is not an integer
                return;
            }
            var inputT120 = Convert.ToInt32(textBox20.Text);
            var inputT150 = Convert.ToInt32(textBox50.Text);
            long result = (inputT120 * chest20 * heroT1Might) + (inputT150 * chest50 * heroT1Might);
            resultLabel.Text = result.ToString();
