    //Code here to pull parent
    Parents P = context.Parents.Find(ParentID);
    //Assign child to said parent during instantiation
    Childs C = new Childs{ Description = "Test", Parents = P};
    context.Childs.Add(C);
    context.SaveChanges();
