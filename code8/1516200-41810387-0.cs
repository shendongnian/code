    protected void Page_Init(object sender, EventArgs e)
    {
        //create a loop for the dynamic fields
        for (int i = 1; i < 6; i++)
        {
            //create a new template field
            TemplateField field = new TemplateField();
            field.HeaderText = "HSE " + i;
            //create the new itemtemplate
            field.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "HSE_" + i);
            //add the field to the grid 
            GridView1.Columns.Add(field);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //normal use of IsPostBack
        if (!IsPostBack)
        {
            //bind the gridview data
            GridView1.DataSource = LoadFromDataBase();
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Text = "PostBack is done!";
    }
    public class GridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        public GridViewTemplate(DataControlRowType type, string colname)
        {
            templateType = type;
            columnName = colname;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            switch (templateType)
            {
                case DataControlRowType.DataRow:
                    DropDownList list = new DropDownList();
                    list.DataSource = LoadFromDataBase();
                    list.DataTextField = "myText";
                    list.DataValueField = "myValue";
                    list.DataBind();
                    container.Controls.Add(list);
                    break;
                default:
                    break;
            }
        }
    }
