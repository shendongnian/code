    private void factorialPow(int num, double x, double y, int selectedIndex)
            {
                switch (selectedIndex)
                {
                    case 0:
                        for (int i = 1; i <= num; i++)
                        {
                            answer = answer * i;
                        }
                        break;
    
                    case 1:
                        m = Math.Pow(x, y);
                        result = m;
                        break;
                }
            }
