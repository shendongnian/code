    var builder = new StringBuilder();
    using (var file = File.OpenRead("your file")) {
         using (var reader = new StreamReader(file)) {
            string line;                    
            while ((line = reader.ReadLine()) != "END_MODULE") {
                builder.AppendLine(line);
            }
         }                
     }
     string final = builder.ToString();
