    foreach (char c in this.NameOfSender){
        if (!Char.IsLetter(c)){
            Console.WriteLine("Wrong Input!");
            getInput();
            break;
        }
    }
