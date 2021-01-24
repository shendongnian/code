    try {
      using (StreamReader myReader = File.OpenText("project.json")) {
        string line = "";
        while ((line = myReader.ReadLine()) != null) {
          Console.WriteLine(line);
        }
      }
    }
    catch (Exception e) {
      MessageBox.Show("FileRead Error: " + e.Message);
    }
