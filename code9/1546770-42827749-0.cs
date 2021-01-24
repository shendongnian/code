    public void PublicHelperMethod()
        {
            Console.WriteLine("Inside Public helper method");
            Console.WriteLine("Calling Private Helper method.." + PrivateHelperMethod());
            Console.WriteLine("Private Helper Method Called!");
        }
        private string PrivateHelperMethod()
        {
            return "Now Inside Private Helper method";
        }
