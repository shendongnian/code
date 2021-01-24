    var orderedData = allLicenceNumbers
     .OrderBy(x =>               
      {  
       var t = x.Split('/');
       for(int i = 0; i < t.Length; i++) //make all elements in the form NNN
       {
         t[i] = "000" + t[i];
         t[i] = t[i].Substring(t[i].Length - 3);
       }
       return string.Join(t, "/");
      }
     )
     .ToList();
