    for(int i=0; i < comingrequestdata.Count(); i++)
    {
        //ObjectExample obj = new ObjectExampole();
        context.ObjectExamples.Add( new ObjectExample {
            Value1 = comingrequestdata[i].Value1,
            Value2 = comingrequestdata[i].Value2,
            Value3 = comingrequestdata[i].Value3
        }
    
    }
    context.SaveChanges();
