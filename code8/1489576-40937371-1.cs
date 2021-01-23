    daParent = new OleDbDataAdapter("SELECT Id, Name, Lorem FROM Parent",
        AceConnStr);
    dsSample.Tables.Add("Parent");
    
    var cbP = new OleDbCommandBuilder(daParent);
    daParent.UpdateCommand = cbP.GetUpdateCommand();
    daParent.InsertCommand = cbP.GetInsertCommand();
    daParent.FillSchema(dsSample.Tables["Parent"], SchemaType.Source);
    daParent.Fill(dsSample.Tables["Parent"]);
    
    
    // repeat for Child - use care with copy-paste!
    daChild = new OleDbDataAdapter("SELECT Id, ParentId, Name, Lorem FROM Child",
                    AceConnStr);
    dsSample.Tables.Add("Child");
    
    var cbS = new OleDbCommandBuilder(daChild);
    daChild.UpdateCommand = cbS.GetUpdateCommand();
    daChild.InsertCommand = cbS.GetInsertCommand();
    daChild.FillSchema(dsSample.Tables["Child"], SchemaType.Source);
    daChild.Fill(dsSample.Tables["Child"]);
    
    // do the same for the subchild adapter
    // omitted for brevity
    // ...
    
    // the PK cols
    DataColumn colParent = dsSample.Tables["Parent"].Columns["Id"];
    DataColumn colChild = dsSample.Tables["Child"].Columns["Id"];
         
    
    // set FK constraints, rules
    ForeignKeyConstraint fkParentChild = new ForeignKeyConstraint("ParentChild",
                colParent, 
                dsSample.Tables["Child"].Columns["ParentId"]);
    fkParentChild.DeleteRule = Rule.Cascade;
    fkParentChild.UpdateRule = Rule.Cascade;
    fkParentChild.AcceptRejectRule = AcceptRejectRule.Cascade;
    dsSample.Tables["Child"].Constraints.Add(fkParentChild);
    
    
    // set FK constraints, rules for Child-SubChild
    ForeignKeyConstraint fkChildSub = new ForeignKeyConstraint("ChildSub",
                 colChild, 
                 dsSample.Tables["SubChild"].Columns["ChildId"]);
    fkChildSub.DeleteRule = Rule.Cascade;
    fkChildSub.UpdateRule = Rule.Cascade;
    fkChildSub.AcceptRejectRule = AcceptRejectRule.Cascade;
    dsSample.Tables["SubChild"].Constraints.Add(fkChildSub);
            
    dsSample.EnforceConstraints = true;
