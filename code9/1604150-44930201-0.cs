        public void output()
        {
            if (marks >= 75)
            {
                Console.WriteLine("Merit");
            }
            else if (marks >= 65 && marks < 75)
            {
                Console.WriteLine("Distiction");
            }
            else if (marks >= 55 && marks < 65)
            {
                Console.WriteLine("Credit");
            }
            else if (marks >= 40 && marks < 55) // Here 40 is passing marks. You've set up of your own
            {
                Console.WriteLine("Pass");
            }
            else Console.WriteLine("Fail");
        }
