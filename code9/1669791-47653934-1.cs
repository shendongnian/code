    for (int i = outlookCalenderItems.Count; i > 0; i--)
    {
         if (outlookCalenderItems[i].Subject.Contains("On Call: Regions:"))
         {
              outlookCalenderItems[i].Delete();
         }
    }
