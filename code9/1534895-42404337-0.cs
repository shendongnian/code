    string longString = "hello world my user-name is stevieray8450";
    int longStringLength = longString.Length;
    char whiteSpace = ' ';
    char hyphen = '-';
    
    // list to store all indexes of white space
    List<int> specialIndexes = new List<int>();
    
    int index = 0;
    do
    {
           index = longString.IndexOf(whiteSpace, index);
           if (index > -1)
           {
                 specialIndexes.Add(index);
                 index++;
           }
     
    } while (index != -1);
