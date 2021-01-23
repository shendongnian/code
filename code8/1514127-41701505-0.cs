    class Program
    {
        static Dictionary<string, int> candidates; //Make the variable accesible from any method for simplicity
        static void Main(string[] args)
        {
            //initialize dictionary
            candidates = new Dictionary<string, int>();
            candidates.Add("Ahmed", 0);
            candidates.Add("Boo", 0);
            candidates.Add("Celine", 0);
            candidates.Add("Didi", 0);
            candidates.Add("Elaine", 0);
            //Print candidate names
            for (int i = 0; i < candidates.Count; i++)
            {
                Console.WriteLine("{0} {1}", i, GetCandidate(i));
            }
       
            //input votes
            Input();
            //output votes if highest vote candidate has any
            if (candidates.Max(c => c.Value) > 0)
            {
                Console.WriteLine("Vote summary");
                Output();
                //to arrange the standings we need to group the candidates to evaluate if they share the same amount of votes
                //additionally I choose to skip the group of candidates who have 0 votes, as there is no point on displaying them
                var grouped_candidates = candidates.GroupBy(c => c.Value).Where(g => g.Key > 0).OrderByDescending(g => g.Key);
                //we can only display 3 names in the standings so we set a counter
                int standing_spots = 3;
                string firstplace = string.Empty, secondplace = string.Empty, thirdplace = string.Empty;
                //retrieve winner(s)
                var first_group = grouped_candidates.ElementAt(0);
                var winner_names = first_group.Select(c => c.Key);
                firstplace = GetStandings("In first place: ", standing_spots, winner_names);
                //retrieve second position(s)
                var second_group = grouped_candidates.ElementAtOrDefault(1);
                if (second_group != null)
                {
                    var second_names = second_group.Select(c => c.Key);
                    secondplace = GetStandings("In second place: ", standing_spots, second_names);
                }
                //retrieve third position(s)
                var third_group = grouped_candidates.ElementAtOrDefault(2);
                if (third_group != null)
                {
                    var third_names = grouped_candidates.ElementAtOrDefault(2).Select(c => c.Key);
                    thirdplace = GetStandings("In third place: ", standing_spots, third_names);
                }
                //Print standings
                if (!string.IsNullOrEmpty(thirdplace)) { Console.WriteLine(thirdplace); }
                if (!string.IsNullOrEmpty(secondplace)) { Console.WriteLine(secondplace); }
                Console.WriteLine(firstplace);
            }
            else
            {
                Console.WriteLine("No votes were made!");
            }
            Console.ReadLine();
        }
        static string GetStandings(string standing_txt, int standing_spots, IEnumerable<string> names)
        {
            if (standing_spots > 0)
            {
                if (names.Count() >= standing_spots)
                {
                    standing_txt += string.Join("+", names.Take(standing_spots));
                    standing_spots = 0;
                }
                else
                {
                    standing_txt += string.Join("+", names);
                    standing_spots -= names.Count();
                }
            }
            return standing_txt;
        }
        static string GetCandidate(int index)
        {
            return candidates.ElementAt(index).Key;
        }
        static void Input()
        {
            int cand_num;
            do
            {
                cand_num = EnterInt("Enter number of candidate you wish to vote for (0 to 4) or -1 to quit:");
                if (cand_num >= 0 && cand_num <= 4)
                {
                    candidates[GetCandidate(cand_num)]++; //increment candidate vote value
                }
                else if (cand_num != -1)
                {
                    Console.WriteLine("Invalid vote");
                }
            } while (cand_num != -1);
        }
        public static void Output()
        {
            foreach (var candidate in candidates)
            {
                Console.WriteLine("{0} {1}", candidate.Key, candidate.Value);
            }
        }
        static int EnterInt(string prompt)
        {
            Console.Write(prompt);
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Error! Please enter an integer number:");
            }
            return num;
        }
    }
