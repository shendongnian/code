    static int[] divisors(int a)
            {
                int x = 0;
                int[] array = new int[x];
                for (int i = 2; i < a; i++)
                {
                    if (a % i == 0)
                    {
                        x++;
                        Array.Resize<int>(ref array, x);
                        array[x-1] = i;
                    }
                }
                if (array.Length == 0)
                    return null;
                else
                    return array;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                int b = Int32.Parse(textBox1.Text);
                int[] a = divisors(b);
                if (a == null)
                    MessageBox.Show($"{b} is a prime number.");
                else
                { 
                    foreach (int x in a)
                    {
                        Debug.Print(x.ToString()); 
                    }
                }
            }
