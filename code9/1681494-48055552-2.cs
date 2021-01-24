    class Man 
    {
     public int Val { get; set; } // try to use properties to hold externally accessible values
    }
    
    public class AllMan // c# uses Pascal casing
    { //Where all classes 'merge'
    
        private Man chosenMan; //Where the chosen it's going to be stored
    
        public AllMan() //Constructor
        {
            //Have all man in one array to easily get the chosen from index
            var men = new Man[] { new Man() { Val = 1 }, new Man() { Val = 2 }, new Man() { Val = 3 } }; 
            var choice = Random.range(0, men.Length); //Randomly get the index
            chosenMan = men[choice]; // Atribute the chosen class
        }
        
        public void DoActionWithChoosedMan()
        {
            Console.WriteLine(chosenMan.Val);
        }
    }
