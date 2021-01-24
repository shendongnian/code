    class Form1 : Form
    {
        public void OnButton1_Click(object sender, EventArgs e)
        {
            CalculateAndDisplayBMI();
        }
    
        private void CalculateAndDisplayBMI()
        {
            int weight = 0;
            int height = 0;
    
            if(!TryGetWeight(out weight))
            {
                MessageBox.Show("Invalid value for weight.")
                return;
            }
    
            if (!TryGetHeight(out height))
            {
                MessageBox.Show("Invalid value for height.")
                return;
            }
    
            double bmi = CalculateBmi(weight, height);
            bmiTxt.Text = $"{bmi}";
        }
    
        private bool TryGetWeight(out int weight)
        {
            if (!int.TryParse(weightTxt.Text, out weight))
                return false;
    
            if (weight <= 10 || weight >= 300) // kgs
                return false;
        }
    
        private bool TryGetHeight(out int height)
        {
            if (!int.TryParse(heightTxt.Text, out height))
                return false;
    
            if (height <= 100 || height >= 250) // cms
                return false;
        }
    
        private double CalculateBmi(int height, int weight)
        {
            double heightInMeters = height / 100d;
            return weight / (heightInMeters * heightInMeters);
        }
    }
