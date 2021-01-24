    foreach (var table in insertTableOrder.OrderByDescending(o => o.Key))
    {
        var targetTable = table.Value.GetChanges(DataRowState.Deleted);
        if (targetTable != null && targetTable.HasChanges())
        {
            var methodName = "CreateSP_" + targetTable.TableName;
    
            SetAction(string.Format("Invoking Reflected method: [{0}], for {1}", methodName, purpose),  "");
            System.Reflection.MethodInfo createSP = this.GetType().GetMethod(methodName);
            object result = createSP.Invoke(this, new object[] { index++, targetTable });
        }
    }
