    try
    {
      UniqueConstraint TableUnique = new UniqueConstraint(new DataColumn[{//Your data});
      dbInstCharges.Table.Constraints.Add(TableUnique);
      //this.dbInstCharges.Table.PrimaryKey = new DataColumn[] {//Your data};
    }
    catch (ArgumentException ex)
    {
      MessageBox.Show("Please enter a unique record");
    }
