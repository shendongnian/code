      using (StreamReader sr = new StreamReader(inputfile))
      {
        using (StreamWriter writer = new StreamWriter(outputfile, false))
        {
          int id = 1;
          while (sr.Peek() >= 0)
          {
            string fileLine = sr.ReadLine();
            //do something with line
            string ttt = fileLine.Replace(" ", ", ");
            writer.WriteLine(ttt + "," + id);
            id++;
          }
        }
      }
