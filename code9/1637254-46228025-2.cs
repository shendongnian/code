       var a = new ArrayList();
       a.Add("Chocolate");
       a.Add("Vanilla");
       a.Add("Crumb");
       var b = (ArrayList) a.Clone();
       bool deep = false;
       for (int i = 0; i < a.Count; ++i) 
         if (!object.ReferenceEquals(a[i], b[i])) {
           // If we have at least one b[i] instance 
           // which doesn't share the corresponding a[i] reference 
           // we can suspect that we perform deep copy
           deep = true;
           break;  
         }
      Console.Write(deep ? "Deep" : "Shallow");
