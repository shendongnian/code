    for(int i=0; i < comingrequestdata.Count(); i++)
    {
        ObjectExample obj = context.ObjectExamples.Where(o => o.ID == Value4); // this is the unique id, assuming it is called ID in the database and Value4 stores its value in your code
        obj.Value1 = comingrequestdata[i].Value1;
        obj.Value2 = comingrequestdata[i].Value2;
        obj.Value3 = comingrequestdata[i].Value3;
        context.ObjectExamples.Attach(obj);
        context.Entry(obj).State = EntityState.Modified;
    }
    context.SaveChanges();
