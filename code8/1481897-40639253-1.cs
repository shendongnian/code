    foreach (var item in list)
    {
        for (int i = 0; i < action?.Style.Length ?? 0; i++)
        {
            action.Style[i] = item.ToString();
            Console.WriteLine(action.Style[i]);
        }                  
    }
