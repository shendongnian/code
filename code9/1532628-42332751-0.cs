                double BMI = 0;
                double weight = 0;
                double height = 0;
    
                //use try parse to test if the value is convertable
                if (!Decimal.TryParse(heightTxt.Text,out height))
                {
                    MessageBox.Show("Not a valid input.");
                    return;
                }
    
                if (!Decimal.TryParse(weightTxt.Text, out weight))
                {
                    MessageBox.Show("Not a valid input.");
                    return;
                }
    
                // declaring and assigning 
                if (weight > 300 || weight < 10)
                {
                    MessageBox.Show("Not a valid input.");
                    //return so the method dosnt try to do the rest of the code
                    return;
    
                }
                if (height > 2.2 || height < 0.2)
                {
                    MessageBox.Show("Not a valid input.");
                    return;
                }
                
                BMI = weight / (height * height);
                //this is how you format the nuumber to two decimal places
                string result = BMI.ToString("#.##");
                resultLbl.Text = "Your BMI is : " + result;
