     LinkedList<int> infoList = new LinkedList<int>(info);
     LinkedList<int> linkList = new LinkedList<int>(link); 
     // Enumerate each collection 
     using (var enInfo = infoList.GetEnumerator()) {
       using (var enLink = linkList.GetEnumerator()) {
         bool proceed = true;
         // until both exausted
         while (proceed) {
           proceed = false; 
           if (enInfo.MoveNext()) {
             proceed = true;
             Console.Write(enInfo.Current + "  ");
           }
           if (enLink.MoveNext()) {
             proceed = true;
             Console.Write(enLink.Current + "  ");
           } 
         }  
       }
     }
