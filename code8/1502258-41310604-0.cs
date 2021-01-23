            // cast the TaskHost's InnerObject as ExecuteSqlTask
            // add a reference to the Microsoft.SqlServer.SQLTask.dll to use ExecuteSqlTask
            ExecuteSQLTask sqlTask = TaskHost.InnerObject as ExecuteSQLTask;
            // call the Add method on ParameterBindings property of sqlTask.
            //This will return a IDTSParameterBinding object
            IDTSParameterBinding parameterBinding = sqlTask.ParameterBindings.Add();
            // using the IDTSParameterBinding object that is returned from the Add call, set the various properties
            parameterBinding.ParameterName = "ParamName";
            parameterBinding.ParameterDirection = ParameterDirections.Input;
            // set more properties on parameterBinding as needed ......
