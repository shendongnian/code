    //using System.Data.Entity;
    using (var db = new MyDbContext())
    {
        db.SomeTable.Load();
        dataGridView1.DataSource = db.SomeTable.Local.ToBindingList();
    }
