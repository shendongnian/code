    static void Main(string[] args)
        {
            Console.WriteLine("--Name of Places--");
            ApplyFor("EdwayApps", "Appxperts", "Genie App Studio", "Appster");
            Console.WriteLine("--Name of Locations--");
            LocationsInOrder("3/424 St kilda", "101/27 Little Collins St", "Contact Online only", "2/377 LonsDale ST");
            Console.WriteLine("--Companies Numbers-- ");
            PhoneNumbers(043990976, 1300939225, 0421336722, 1800709291);
            Console.ReadLine();
        }
        static void ApplyFor(string num1, string num2, string num3, string num4)
        {
            //Literally just the job names 
            Console.WriteLine(num1 + "\n"+num2 + "\n" + num3 + "\n " + num4);
        }
        // Job Locations
        static void LocationsInOrder(string loc1, string loc2, string loc3, string loc4)
        {
            Console.WriteLine(loc1 + "\n" + loc2 + "\n" + loc3 + "\n " + loc4);
        }
        //Contact - references
        static void PhoneNumbers(int phn1, int phn2, int phn3, int phn4)
        {
            Console.WriteLine(phn1 + "\n" + phn2 + "\n" + phn3 + "\n " + phn4 +"\n");
        }
