    if (userTestDate.Month < 3)
      userTestDate = new DateTime(userTestDate.Year, 3, 1); 
    else if (userTestDate.Month < 9)
      userTestDate = new DateTime(userTestDate.Year, 9, 1);
    else
      userTestDate = new DateTime(userTestDate.Year + 1, 3, 1);
