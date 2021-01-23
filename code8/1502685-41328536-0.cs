    private void Foo()
            {
                double d2 = 4848484.000000;
           
                if (d2 - Math.Round(d2) != 0)
                {
                    Console.WriteLine(d2.ToString());
                }
    
                else
                {
                    Console.WriteLine(d2.ToString("0.00####"));
                }
            }
