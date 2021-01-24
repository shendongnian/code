     var MIS = string.Join(" ", MentionsList.ToArray());
     string Mentionsintext = MIS.ToString();
    
     using (StreamWriter MentionFile = new StreamWriter(@"C:\Users\User\Documents\Mentions.txt")) {
    
          MentionFile.WriteLine(Mentionsintext + Environment.NewLine);
     }
