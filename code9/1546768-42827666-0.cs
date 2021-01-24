    class Car1
    {
        public void PublicHelperMethod()
        {
            Console.WriteLine("Inside Public helper method");
            Console.WriteLine("Calling Private Helper method.." + PrivateHelperMethod());
        }
        private string PrivateHelperMethod()
        {
            return "Private Helper Method Called!\nNow Inside Private Helper method";
        }
    }
