    int number = 5;
    string binaryRep = Convert.ToString(number, 2);
    List<int> myList = new List<int>();
    int pow = 0;
    for(int i = binaryRep.Count() - 1; i >= 0; i--)
    {
        if(binaryRep[i] == '1')
        {
            myList.Add((int)Math.Pow(2, pow));  
        }
        pow++;
    }
