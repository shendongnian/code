     public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
     {
         var status = value as WhateverType;
         if (status == someValue1)
         {
             return ImageSource.FromFile("status1Image.png");
         }
         else if(status == someValue2)
         {
             return ImageSource.FromFile("status2Image.png");
         }
         ......
     }
