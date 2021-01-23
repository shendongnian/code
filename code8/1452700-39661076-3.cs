    for (int i = 0; i < rowLength; i++)
    {
         for (int j = 0; j < colLength; j++)
         {
             Console.Write(string.Format("{0} ", itemList[i, j]));
         }
         Console.Write(Environment.NewLine + Environment.NewLine);
    }
