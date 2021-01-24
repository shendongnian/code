    if (!IsPostBack)
    {
        var list = new List<Student>();
        list.Add(new Student() {StudentID = 1, StudentName = "111"});
        list.Add(new Student() {StudentID = 2, StudentName = "222"});
        grd.DataSource = list;
        grd.DataBind();
    }
