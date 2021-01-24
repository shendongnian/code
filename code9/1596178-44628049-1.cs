     if (attach.HasFile)
     {
        if ((int)(attach.PostedFile.ContentLength * 0.000001) < 10)
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
     
