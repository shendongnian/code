     [HttpPost]
    public ActionResult FieldQueryResult(QueryInput input, bool exportCsv)
    {
     //build my csv string, sb
      this.Session["fileString"] = sb.ToString();
     ...
     }
