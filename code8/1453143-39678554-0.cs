    class StudentMarks 
    { 
      public const int Max = 50; 
      public string Surname { get; set; } 
      public string Name { get; set; } 
      public string Group { get; set; }                                                                       
      public int[] Marks { get; private set; } 
     
      public StudentMarks(string surname, string name, string group, int amountOfMarks) 
      { 
        Surname = surname;                                                                                    
        Name = name; 
        Group = group; 
        Marks = new int[amountOfMarks]; 
      } 
    } 
     
    public static void ReadData(out StudentMarks[] Students, out int amount) 
    { 
      amount = 0; 
      Students = new StudentMarks[Max]; 
      using (StreamReader reader = new StreamReader("C:\\Users\\Andrius\\Desktop\\Mokslams\\C#\\Pratybos\\P3\\P3.2\\StudentsMarks.csv")) 
      { 
        reader.ReadLine(); reader.ReadLine(); 
        string line = null; 
        while (null != (line = reader.ReadLine())) 
        { 
          string[] values = line.Split(','); 
          string surname = values[0]; 
          string name = values[1]; 
          string group = values[2]; 
          int i = 0; int yMax = 3 + amountOfMarks;int yMin = 4; 
          Students[amount]  = new StudentMarks(surname, name, group, amountOfMark); 
          while (amountOfMarks >= i) 
          { 
            if (yMin <= yMax) 
            { 
              Students[amount].Marks[i] = int.Parse(values[yMin]); 
              yMin++; 
            } 
            i++; 
          } 
          amount++; 
        } 
      } 
    }
 
