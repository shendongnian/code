    for(int i=0; i<myClass.Result.Count;i++){
       if(myClass.Result[i].Volume > myClass.Result[i+1].Volume)
       {
          Console.WriteLine("Volume "+i+": "+myClass.Result[i].Volume+" is higher then volume "+(i+1)+": " + myClass.Result[i+1].Volume);
       }
       if(myClass.Result[i].Last > myClass.Result[i+1].Last)
       {
          Console.WriteLine("Last "+i+": "+myClass.Result[i].Last +" is higher then last "+(i+1)+": " + myClass.Result[i+1].Last );
       }
       
    }
