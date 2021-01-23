    string test = string.Join(Environment.NewLine, cptarray
      .Select((line, index) => string.Format("cptarray[{0}] = {1}", 
         index,
         string.Join(", ", line.Select(item => "\"" + item + "\"")))));
    Console.Write(test);
