      protected void btnGetFiles_Click(object sender, EventArgs e)
      {
          try
          {
              StringBuilder content = new StringBuilder();
              if (Directory.Exists(Server.MapPath("Relative path here")))
              { 
                  // Execute this if the directory exists
                  foreach (string file in Directory.GetFiles(Server.MapPath("Relative path here"),"*.txt"))
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
