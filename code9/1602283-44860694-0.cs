     public void Import(DataSet1 dataSet1)
            {
                //this.Group.Load(dataSet1.Group.CreateDataReader());
                foreach(var group in dataSet1.Group)
                {
                    GroupRow g  =this.Group.NewGroupRow();
                    g.Class = group.Class;
                    g.Grade = group.Grade;
                    this.Group.AddGroupRow(g);
                }
            } 
