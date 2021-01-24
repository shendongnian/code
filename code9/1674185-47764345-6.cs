        static void Main(string[] args)
        {
            string input = "";
            while(input != "exit" || input != "Exit")
            {
                Console.Write("Input: ");
                input = Console.ReadLine();
                string inputDate = input;
                try
                {
                    
                    DateTime date = DateTime.Parse(inputDate);
                    Console.WriteLine(date+"\n");
                    string month = date.Month.ToString();
                    string day = date.Day.ToString();
                    string year = date.Year.ToString();
                    string resultingString = month + " " + day + " " + year;
                    Console.WriteLine(resultingString);
                }
                catch(Exception e)
                {
                    //Exceptions. String not valid because ambiguity
                    try
                    {
                       Console.WriteLine( myParser(inputDate) );
                    }
                    catch
                    {
                        Console.WriteLine("Ambiguous");
                    }
                    
                    //Console.WriteLine("Ambiguous.\n");
                    //In here can also perform other logic, of course
                }
                
            }
            
        }
        static string myParser(string input)
        {
            string month,day,year,date;
            
            switch (input.Length)
            {
                //In the case that it's 1 character in length 
                case 1:
                    return "Ambiguous.";
                case 2:
                    return "Ambiguous.";
                //did user mean #/#/200#?  hopefully not #/#/199#...
                case 3:
                    month = input.Substring(0, 1);
                    day = input.Substring(1, 1);
                    year = input.Substring(2, 1);
                    date = month + " " + day + " " + year;
                    return date;
                //did user mean  # # 20## 
                //or             # ## 200# 
                //or             ## # 200#
                case 4:
                    
                    return "Ambiguous";
                //user probably means ## # ##
                case 5:
                    return "Ambiguous";
                case 6:
                    return "Ambiguous";
                default:
                    return "Ambiguous";
            }
            
        }
