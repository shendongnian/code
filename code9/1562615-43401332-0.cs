    foreach (var item in query_1.GroupBy(x=> x.Name).Select(x=> x.First()))
    {
       MultipleTableQueryResultVM objcvm = new MultipleTableQueryResultVM();
       objcvm.firstName = item.Name;
       objcvm.CommerceTransID = item.TransID;
       objcvm.Type = item.Tipo;
       objcvm.Name = item.Nombre;
       VMList.Add(objcvm);
    }
