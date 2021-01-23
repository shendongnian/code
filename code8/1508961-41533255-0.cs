    using System;
    
    class rockpsV2
    {
    
    public static string[] choices = new string[]  { "rock", "paper", "scissor" };
    public static int comparePlay(string player1, string player2) 
    {
        if (player1 == player2)
            return  0;
    
        if (player1 == "rock" && player2 == "scissor" ||
            player1 == "paper" && player2 == "rock" ||
            player1 == "scissor" && player2 == "paper")
            return -1;
    
        return 1;
    }
    
    
    public static bool validChoice(string choice) 
    {
        return choice == "rock" 
                || choice == "scissor"
                || choice == "paper";
    
    }
    
    public static void Main(string[] args)
    {
        
        string userChoice = "";
       do
       {
           do {
            Console.WriteLine("Do you want to play rock,paper or scissors?");
            userChoice = Console.ReadLine();       
    
            if (!validChoice(userChoice)) {
                Console.WriteLine("You must choose rock,paper or scissors!");        
            }
    
           }
           while(!validChoice(userChoice));
    
    
            Random r = new Random();
            int computerChoiceRand = r.Next(100) % 3;
            string computerChoice = choices[computerChoiceRand];
    
            Console.WriteLine("The computer chose {0}", computerChoice);
            
            int whoWins = comparePlay(computerChoice, userChoice);
    
            if (whoWins < 0) {
                Console.WriteLine("Sorry you lose, {0} beats {1}", computerChoice, userChoice);
            }
    
            if (whoWins == 0) {
                Console.WriteLine("It is a tie");
            }
    
            if (whoWins > 0) {
                Console.WriteLine("You win,{0} beats {1}", userChoice, computerChoice);
            }
    
            Console.WriteLine("Want to play again?");
            } while(Console.ReadLine() == "yes");
        }
    }
