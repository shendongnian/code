    string [] array = input.Split("\\s+");
        foreach(string a in list)
        {
            bool yes = false;
            for(int i = 0; i < array.Length-1; ++i ){
                string test = array[i] + " " + array[i+1];
                if(a.Contains(test)){
                    yes = true;
                }
            }
            Console.WriteLine(yes);
        }
