            int val1 = 0;
            int val2 = 1;
            Int64 evenTerms = 0;
            int val3 = int.Parse(textBox3.Text), val4 = 0, temp;
            if (val3 < 5000000)
            {
                while (val4 < val3){
                  temp = val1 + val2;
                  val1 = val2;
                  val2 = temp;
                  if (temp % 2 == 0)
                  {
                      evenTerms += 1;
                  }
                }
            }
            MessageBox.Show("" + evenTerms);
