    static void Main(string[] args)
    {
        //Create participants set
        string[] participants = {"James","John","Tyrone","Rebecca","Tiffany","Judith"};
        
        //Create not allowed lists
        string[] jamesNotAllowedList = {"Tiffany", "Tyrone"};
        string[] johnNotAllowedList = {};
        string[] tyroneNotAllowedList = {};
        string[] rebeccaNotAllowedList ={"James", "Tiffany"};
        string[] judithNotAllowedList = {};
        //Create list of not allowed lists
        string[][] notAllowedLists = { jamesNotAllowedList, johnNotAllowedList, tyroneNotAllowedList, rebeccaNotAllowedList, judithNotAllowedList};
        //Create dictionary<Tuple<string,string>, bool> from participants array by using cartesian join on itself
        Dictionary<Tuple<string, string>, bool> dictionary = participants.SelectMany(left => participants, (left, right) => new Tuple<string, string>(left, right)).ToDictionary(item=> item, item=>true);
        //Loop through each person who owns a notAllowedList 
        for (int list = 0; list < notAllowedLists.Length; list++)
        {
            //Loop through each name on the not allowed list
            for (int person = 0; person<notAllowedLists[list].Length; person++)
            {
                string personNotAllowing = participants[list];
                string notAllowedPerson = notAllowedLists[list][person];
                //Change the boolean value matched to the composite key
                dictionary[new Tuple<string, string>(personNotAllowing, notAllowedPerson)] = false;
                Console.WriteLine(personNotAllowing + " did not allow " + notAllowedPerson);
            }
        }                
        //Then since a participant cant pick itself
        for(int abc=0;abc<participants.Length;abc++)
        {
            //remove clone set
            Tuple<string, string> clonePair = Tuple.Create(participants[abc], participants[abc]);
            dictionary.Remove(clonePair);
        }
        //Display whats going on with this Dictionary<Tuple<string,string>, bool>
        Console.WriteLine("--------Allowed?--Dictionary------------\n");
        Console.WriteLine(string.Join("  \n", dictionary));
        Console.WriteLine("----------------------------------------\n\n");
        
        //Create Random Object
        Random rand = new Random();
        
        //Now that the data is organized in a dictionary..
          //..Let's have random participants pick random participants
        
        //For this demonstration lets try it 10 times
        for (int i=0;i<20;i++)
        {
            //Create a new random participant
            int rNum = rand.Next(participants.Length);
            string randomParticipant = participants[rNum];
            //Random participant picks a random participant
            string partner = participants[rand.Next(participants.Length)];
            
            //Create composite key for the current pair
            Tuple<string, string> currentPair = Tuple.Create(partner,randomParticipant);
            //Check if it's a valid choice
            try
            {
                if (dictionary[currentPair])
                {
                    Console.WriteLine(randomParticipant + " tries to pick " + partner);
                    Console.WriteLine("Valid.\n");
                    //add to dictionary
                    for(int j=0; j<participants.Length;j++)
                    {
                        //Make the partner never be able to be picked again
                        Tuple<string, string> currentPair2 = Tuple.Create(partner, participants[j]);
                        try
                        {
                            dictionary[currentPair2] = false;
                        }
                        catch
                        {
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine(randomParticipant + " tries to pick " + partner);
                    Console.WriteLine(">>>>>>>>Invalid.\n");
                }
            }
            catch
            {
                //otherwise exception happens because the random participant
                  //And its partner participant are the same person
                //You can also handle the random participant picking itself differently
                  //In this catch block
                //Make sure the loop continues as many times as necessary
                //by acting like this instance never existed
                i = i - 1;
            }
            
           
        }
        Console.ReadLine();
    }
