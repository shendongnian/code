      protected void btnGetFiles_Click(object sender, EventArgs e)
      {
          try
          {
              StringBuilder content = new StringBuilder();
              if (Directory.Exists(@"C:\samplePath"))
              { 
                  // Execute this if the directory exists
                  foreach (string file in Directory.GetFiles(@"C:\samplePath","*.txt"))
                  {
                       // Iterates through the files of type txt in the directories
                      content.Append(File.ReadAllText(file)); // gives you the conent
                  }
                    txtContent.Text = content.ToString();
              }
          }
          catch
          {
              txtContent.Text = "Something went wrong";
          }
    
      }
