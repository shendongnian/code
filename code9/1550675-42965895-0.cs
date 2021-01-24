                if (dblQuantitySold >= 10 && dblQuantitySold < 20)
                {
                    dblAmountTotalDue -= dblQuantitySold * dblPrice * 0.05;
                    MessageBox.Show("A 5% discount will be given because 10 or more has been sold.");
                }
               
