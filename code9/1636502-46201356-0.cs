    public static void FillDropDownWithoutSelect(DropDownList ddl, object Datasource, string ValueField, string TextField)
            {
                ddl.DataSource = Datasource;
                ddl.DataTextField = TextField;
                ddl.DataValueField = ValueField;
                ddl.DataBind();
            }
    
           
    
            public static void FillListBoxWithoutSelect(ListBox ddl, object Datasource, string ValueField, string TextField)
            {
                ddl.DataSource = Datasource;
                ddl.DataTextField = TextField;
                ddl.DataValueField = ValueField;
                ddl.DataBind();
            }
    
            public static void FillCheckBoxListWithoutSelect(CheckBoxList ddl, object Datasource, string ValueField, string TextField)
            {
                ddl.DataSource = Datasource;
                ddl.DataTextField = TextField;
                ddl.DataValueField = ValueField;
                ddl.DataBind();
            }
