    private void factorialOrPow(int num, double x, double y, int selectedIndex)
            {
                switch (selectedIndex)
                {
                    case 0:
                        factorial(num);
                        break;
    
                    case 1:
                        pow(x, y);
                        break;
                }
            }
