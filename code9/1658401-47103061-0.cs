    static void Main(string[] args)
    {
        char response;
        string[] workerName = new string[MAX_LIST_VALUE]; //100
        int i;
        // No need to check the length, you already know that
        for (i = 0; i < MAX_LIST_VALUE; i++)
        {
            Write("Do You Want To Enter A Worker's Name? Y or N: ");
            response = Convert.ToChar(ReadLine());
            if (response == 'Y' || response == 'y')
            {
                Write("Please Enter The Worker's Name: ");
                workerName[i] = ReadLine();
            }
            // This is an alternative condition so use 'else if' 
            else if (response == 'N' || response == 'n')
            {
                // exit for loop
                break;
            }
        }
    }
