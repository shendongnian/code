     public class allMan
       { 
        //Where all classes 'merge'
        private dynamic chosenMan; //Where the chosen it's going to be stored
        public allMan() //Constructor
        {
            //Have all man in one array to easily get the chosen from index
            object[] men = new object[] { new man1(), new man2(), new man3() };
            var choice = Random.range(0, men.Length); //Randomly get the index
            chosenMan = men[choice]; // Atribute the chosen class
        }
        public void doActionWithChoosedMan()
        {
            Console.WriteLine(chosenMan.val); //ERROR
        }
    }
