     if (attach.HasFile)
     {
        if (attach.PostedFile.ContentLength > 10240)
        {
            e.IsValid = true;
        }
        else
        {
            e.IsValid = false;
        }
     }
     else
     {
         e.IsValid = false;
     }
     
