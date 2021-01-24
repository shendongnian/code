        bool IsValid = false;
        ///Prompt user to reenter value if the input is illegal
        do 
        {
            ///Prompt the user for the rate
            Console.Write("Enter the rate: ");
            input2 = Console.ReadLine();
            IsValid = double.TryParse(input2, out r);
        } while(!IsValid && r < 0);
