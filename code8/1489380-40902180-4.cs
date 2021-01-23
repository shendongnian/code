    public ActionResult Index()
    {
        DataMappingViewModel model= new DataMappingViewModel()
        {
            TableName = "TABLENAME",
            ColumnList = data.GetTableColumns("TABLENAME").Select(x => x.COLUMN_NAME),
            XmlElements = new List<XmlElement>()
            {
                new XmlElement()
                {
                    ElementName = "element1",
                    SelectedColumn = "...." // if you want to preselect an option
                }
            }
        }
        return View(model);
    }
