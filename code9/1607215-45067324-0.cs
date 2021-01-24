    Web myWeb = ctx.Web;
    List myList = myWeb.Lists.GetByTitle("Company Employees");
    SPClient.View view = myList.DefaultView;
    CamlQuery qry = new CamlQuery();
    qry.ViewXml =
    "<Where><Eq><FieldRef Name=\"Management\"/><Value Type='Text'>Yes</Value></Eq></Where>";
    ViewCollection viewColl = myList.Views;
    string[] viewFields = { "Title", "Promoted", "Intern", "Management" };
    ViewCreationInformation creationInfo = new ViewCreationInformation();
    creationInfo.Title = "Management";
    creationInfo.RowLimit = 50;
    creationInfo.ViewFields = viewFields;
    creationInfo.ViewTypeKind = ViewType.None;
    creationInfo.SetAsDefaultView = false;
    creationInfo.Query = qry.ViewXml;
    viewColl.Add(creationInfo);
    ctx.ExecuteQuery();
