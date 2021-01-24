    using (var context = new YourContext())
    {
        foreach( var model1 in context.SetModel1 )
        {
            context.SetModel2.Add(
                new Model2() { prop1 = model1.prop1, prop2 = model1.prop2 }
            );
        }
        context.SaveChanges();
    }
