    protected SharpDX.D3DCompiler.ShaderBytecode LoadShaderFromManifestResourceFile(
    			System.Reflection.Assembly assembly, string resourceName)
    	{
    		SharpDX.D3DCompiler.ShaderBytecode shaderBytecode = null;
    
    		using (var shaderCodeReader = assembly.GetManifestResourceStream(resourceName))
    		{
    			shaderBytecode = ToDispose(ShaderBytecode.FromStream(shaderCodeReader));
    		}
    
    		return shaderBytecode;
        }
