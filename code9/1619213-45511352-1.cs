    	string shaderFile = @"SomeDirectoryInYourApp\Shaders\MyVS.cso";
    	if (!Path.IsPathRooted(shaderFile))
    	{
             shaderFile = Path.Combine(System.IO.Path.GetDirectoryName(
    		     System.Reflection.Assembly.GetEntryAssembly().Location),
    		shaderFile);
    	}
       		
    	using (var shaderCodeReader = new System.IO.StreamReader(shaderFile))
    	{
   			vertexShaderBytecode = ToDispose(ShaderBytecode.FromStream(
   				shaderCodeReader.BaseStream));
   		}
    
   		vertexShader = ToDispose(new VertexShader(device, vertexShaderBytecode));
