    string[] Days = System.IO.File.ReadAllLines(@"C: \Users\Illimar\Desktop\Algorithms and Comlexity2\Day_1.txt");
    string[] Depths = System.IO.File.ReadAllLines(@"C: \Users\Illimar\Desktop\Algorithms and Comlexity2\Depth_1.txt");
    ...
    string[] newArray = new string[Days.Length];
    for(int x = 0; x < Days.Length;x++)
    {
         newArray[x] = string.Format("{0} {1}", Days[x], Depths[x]);
    }
