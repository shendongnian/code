    foreach (var table in insertTableOrder.OrderBy(o => o.Key))
    {
        var targetTable = table.Value.GetChanges(DataRowState.Added | DataRowState.Modified);
        if (targetTable != null && targetTable.HasChanges())
        {
            var methodName = "CreateSP_" + targetTable.TableName;
    
            System.Reflection.MethodInfo createSP = this.GetType().GetMethod(methodName);
            object result = createSP.Invoke(this, new object[] { index++, targetTable });
        }
    }
