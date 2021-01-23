    public static void Main()
    {
        int[] selection = new int[] //array for the age requirements of each film
        {
        15, 15, 12, 18, 0
        };
        string filmNumberText; //console input for the film number 
        int filmNumber; //input string parsed as integer 
        string ageText; //console input for age
        int age; //parsed age string
        int ageLimit; //age requirement for selected film
        Console.Write("Welcome to our Multiplex.\n\n");
        Console.WriteLine(@"We are presently showing:
    1. Rush (15) 
    2. How I Live Now (15)
    3. Thor: The Dark World (12A)
    4. Filth (18)
    5. Planes (U)");
        do  //loops as long as input is not between 1 and 5
        {
            Console.Write("\nEnter the number of the film you wish to see: ");
            filmNumberText = Console.ReadLine();
        } while (int.TryParse(filmNumberText, out filmNumber) == false || (filmNumber < 1 || filmNumber > 5));
        filmNumber = filmNumber - 1; //changes input from 1-5 to 0-4
        ageLimit = selection[filmNumber]; //selects age requirement from array
        //loops as long as input is not an integer
        do
        {
            Console.Write("\nPlease enter an age between 0 and 125:");
            ageText = Console.ReadLine();
        } while (int.TryParse(ageText, out age) == false || (age < 0 || age > 125)); //check again if input is an integer
        if (age < ageLimit) //if too young for the given film
        {
            Console.WriteLine("\nAccess denied - you are too young");
        }
        else
        {
            Console.WriteLine("\nPlease call our office at 888-999-2928 to reserve tickets.");
        }
        Console.Read();
    }
