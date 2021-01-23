    // Assuming changes were applied on DS/DT rows, 
    // changed rows should be duly marked, so just
    // run the updates
    
    // insert first
    
    DataTable parentRows = dsSample.Tables["Parent"].GetChanges(DataRowState.Added);
    DataTable childRows = dsSample.Tables["Child"].GetChanges(DataRowState.Added);
    DataTable subChRows = dsSample.Tables["SubChild"].GetChanges(DataRowState.Added);
    
    // dont Update the DS.Tables...it will try
    // to do ALL pending changes
    if (parentRows != null)
        daParent.Update(parentRows);
    
    if (childRows != null)
        daChild.Update(childRows);
    
    if (subChRows != null)
        daSubCh.Update(subChRows);
    
    // then update..order doesnt matter
    parentRows = dsSample.Tables["Parent"].GetChanges(DataRowState.Modified);
    childRows = dsSample.Tables["Child"].GetChanges(DataRowState.Modified);
    subChRows = dsSample.Tables["SubChild"].GetChanges(DataRowState.Modified);
    if (parentRows != null)
        daParent.Update(parentRows);
    
    if (childRows != null)
        daChild.Update(childRows);
    
    if (subChRows != null)
        daSubCh.Update(subChRows);
    
    // then deletes...in reverse order!
    parentRows = dsSample.Tables["Parent"].GetChanges(DataRowState.Deleted);
    childRows = dsSample.Tables["Child"].GetChanges(DataRowState.Deleted);
    subChRows = dsSample.Tables["SubChild"].GetChanges(DataRowState.Deleted);
    if (subChRows != null)
        daSubCh.Update(subChRows);
    
    if (childRows != null)
        daChild.Update(childRows);
    
    if (parentRows != null)
        daParent.Update(parentRows);
    
    // our work is done...time for cheesecake
    dsSample.AcceptChanges();
