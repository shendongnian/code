    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
            {
                int numrsa1 = Int32.Parse(this.numericUpDown2.Value.ToString());
    
                if (IsPrimeNumber(numrsa1))
                {
                    this.numericUpDown2.Value = numrsa1;
                }
                else
                {
                    this.numericUpDown2.UpButton();
                }
            }
    
            static bool IsPrimeNumber(int value)
            {
                bool result = true;
    
                for (int i = 2; i < value; i++)
                {
                    if (value % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
    
                if (value <= 1)
                    result = false;
    
                return result;
            }
