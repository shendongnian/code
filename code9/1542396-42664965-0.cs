      bool bTry=true;
      While(bTry)
      {
       ..Your..
       ..Other.. 
       ..Code..
       ..
         bTry=CanCountinue();
      }
        /// <summary>
        /// Used to continue
        /// </summary>
        /// <returns>True if user want to continue
        /// False if user want to exit</returns>
        public bool CanCountinue()
        {
            Console.WriteLine("Enter Y to continue...");
            String sAnother = Console.ReadLine();
            return String.Compare(sAnother, "Y", true) ==0;
        }
   
