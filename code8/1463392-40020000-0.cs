    Public ActionResult FuncA(string myvalue){
    if (myvalue.Trim() != String.Empty && !myvalue.EndsWith(";"))
    {
        myvalue += ";";
    }
    string[] sadObjects = HttpUtility.HtmlDecode(myvalue).Split(';');
    myvalue += HttpUtility.HtmlEncode(ado.Name) + "; ";
    }
