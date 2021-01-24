    <#
    	IEnumerable<PropertyMetadata> properties = ModelMetadata.Properties;
    	foreach (PropertyMetadata property in properties) 
    	{
            if(property.IsComplexType)
            {
    			System.Reflection.Assembly myAssembly = System.Reflection.Assembly.LoadFile("C:\\myFullAssemblyPath\\bin\\Release\\myAssembly.dll");
                Type myType = myAssembly.GetType(property.TypeName);
    
    			if(myType == null)
    			{
    #>
        <th>TODO:  (Null type) Unable to render complex type #></th>
    <#   			
    			}
    			else
    			{
    				foreach(var currentComplexProperty in myType.GetProperties())
    				{
    					string fullComplexName = property.PropertyName + "." + currentComplexProperty.Name;    
    #>
    			<th id="<#= fullComplexName #>">
    				<#= fullComplexName #>
    			</th>
    <#        
    				}
    			}
            }
        }
    #>
