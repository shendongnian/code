    var dt1 = new DataTable();
    var p1 = dt1.Columns.Add("ID", typeof(string));
    dt1.Columns.Add("Name", typeof(string));
    dt1.Columns.Add("Address", typeof(string));
    dt1.Columns.Add("Qty", typeof(int));
    dt1.Columns["Qty"].DefaultValue = 0; //Setting default value
    dt1.Rows.Add("A1", "Dog", "C1", 100);
    dt1.Rows.Add("A2", "Cat", "C3", 200);
    dt1.Rows.Add("A3", "Chicken", "C2", 300);
    dt1.Rows.Add("A4", "Mouse", "C4", 400);
    dt1.Rows.Add("A5", "Pig", "C5", 500);
    dt1.PrimaryKey = new DataColumn[] { p1 };
    var dt2 = new DataTable();
    var p2 = dt2.Columns.Add("ID", typeof(string));
    dt2.Columns.Add("Name", typeof(string));
    dt2.Columns.Add("Address", typeof(string));
    dt2.Columns.Add("Qty Max", typeof(int));
    dt2.Columns["Qty Max"].DefaultValue = 0; //Setting default value
    dt2.Rows.Add("A1", "Dog", "C1", 600);
    dt2.Rows.Add("A2", "Cat", "C3", 700);
    dt2.Rows.Add("A3", "Chicken", "C2", 800);
    dt2.Rows.Add("A6", "Rabbit", "C6", 900);
    dt2.PrimaryKey = new DataColumn[] { p2 };
    var dt3 = dt1.Copy();
    dt3.Merge(dt2);
