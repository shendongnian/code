            double weight = 0;
            double height = 0;
            if (Double.TryParse(weightTxt.Text, out weight) && Double.TryParse(heightTxt.Text, out height)) {
                if (weight > 300 || weight < 10 || height > 2.2 || height < 0.2)
                {
                    MessageBox.Show("Not a valid input.");
                }
                double BMI = weight / (height * height);
                
                /*Two ways for converting to two didges:*/
                // 1.
                // Round to two didgets
                double result = Math.Round(BMI, 2);
                // convert result to string
                string resultString = Convert.ToString(result);
                 
                // 2.
                string resultString = BMI.ToString("#.##")               
            }       
