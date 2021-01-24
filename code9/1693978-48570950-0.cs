    var listTitle = "Site Pages";
    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var items = list.GetItems(CamlQuery.CreateAllItemsQuery());
    ctx.Load(items, icol => icol.Include( i => i["WikiField"], i => i["CanvasContent1"], i => i["FileRef"], i => i.ContentType));
    ctx.ExecuteQuery();
    foreach (var item in items)
    {
         Console.WriteLine(">>> {0}", item["FileRef"]);
         switch (item.ContentType.Name)
         {
            case "Site Page":
              Console.WriteLine(item["CanvasContent1"]);
              break;
            case "Wiki Page":
              Console.WriteLine(item["WikiField"]);
              break;
         }    
     }
  
