    foreach(var toUpdate in result){
        toUpdate.Client_ID = q.First(); // or int.Parse(q.First());
        Context.Entry(toUpdate).State = EntityState.Modified;
    }
    Context.SaveChanges();
