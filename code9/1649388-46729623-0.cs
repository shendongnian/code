           public int enum GlobalType
           {
              One = 1,
              Two = 2,
              Individual = 3
            }
       //enum value Convert to int or other data type using casting
       item.AnnouncementType = (int) GlobalType.One;
        //Suppose if condition using 
        if((GlobalType)item.AnnouncementType==GlobalType.One)
        {
           //your code
        }
