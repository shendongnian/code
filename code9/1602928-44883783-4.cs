    string str = "Today is a nice day, and I have been driving a car";
            
    str =  Regex.Replace(str, "[^0-9a-zA-Z ]+", "");
    
    string[] arr = str.Split(' ');
    int nElements = 0;
    
    for (int i = 0; i < arr.Length; i+=3)
    {
        if(i+3 < arr.Length)
        {
            nElements = 3;
        }
        else
        {
            nElements = arr.Length - i;
        }
    	Console.WriteLine(arr.Skip(i).Take(nElements).Aggregate((current, next) => current + " " + next));
    }
