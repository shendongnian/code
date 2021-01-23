    char[] chArray = this.textBox1.Text.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; (i < chArray.Length); i++) 
                {
                
                   numArray[i] = ((int)(char.GetNumericValue(chArray[i])));
                }
