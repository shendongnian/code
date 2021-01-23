    //declare this variable in your class
    public string Name = null;
    //change the return type to void
    public void getInput(){
        string CheckString = null;
        while (Name.IsNullOrEmpty()){
            bool IsValid = true;
            checkString = Console.ReadLine();
            foreach (char c in CheckString.ToCharArray()){
                if (!Char.IsLetter(c)){
                    Console.WriteLine("Wrong Input!");
                    IsValid = false;
                    break;
                }
            }
            if (IsValid){
                Name = CheckString;
            }
        }
    }
