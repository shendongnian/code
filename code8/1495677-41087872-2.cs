    string input = "ArrayWithR23andomChar44acter3sWit55hNumbersI6nIt";
    char[] array = input.ToCharArray();
    for(int i=0; i < array.Length; i++)
    {
        if ((int)input[i] >= 48 && (int)input[i] <=57)
        {
            array[i] = '*';
        }
    }
