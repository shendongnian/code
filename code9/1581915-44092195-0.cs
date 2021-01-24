    public static void mymethod()
    {
        Employee employee = null
        while(employee == null)
        {
            Console.WriteLine("Please enter your Employee ID: ");
            int ID = 0;
            var input = Console.ReadLine();
            if(int.TryParse(input, out ID))
            {
                employee = controllerclass.findemployee(ID);
                if(employee == null)
                {
                    Console.WriteLine("The employee does not exist");
                }
                else
                {
                    Console.WriteLine("The employee exists");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid ID.");
            }
        } // Doesn't exit the loop until we have an employee
       
