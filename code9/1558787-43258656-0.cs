    Public NotInheritable Class SqlDataSourceEnumerator _
    	Inherits DbDataSourceEnumerator
    
    Dim instance As SqlDataSourceEnumerator   
    
    Dim dataTable As System.Data.DataTable = instance.GetDataSources() 
