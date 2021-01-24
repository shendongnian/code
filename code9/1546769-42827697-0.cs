    class Car1
    {
        public void PublicHelperMethod()
        {
            Console.WriteLine("Inside Public helper method");
            Console.WriteLine("Calling Private Helper method..");
            Console.WriteLine(PrivateHelperMethod());        
        }
        private string PrivateHelperMethod()
        {
            Console.WriteLine("Private Helper Method Called!");
            return "Now Inside Private Helper method";
        }
    }
