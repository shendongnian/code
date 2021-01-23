          string FullNote = "aaa bbb ccc bbb ddd bbb eee";
          string ExistingAdminNote = "bbb";
    
          string[] NoteDifference = FullNote.Split(new string[] { ExistingAdminNote }, StringSplitOptions.None);
    
          int index = 0;
          for (int ii = 0; ii < NoteDifference.Length; ii++)
          {
            ResponseWriteLine("INCREMENT: " + index++ + "--" + NoteDifference[ii] + "<br>");
            if (ii < NoteDifference.Length - 1)
              Response.WriteLine("INCREMENT: " + index++ + "--" + ExistingAdminNote + "<br>");
          }
