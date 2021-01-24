    using System.Runtime.InteropServices.WindowsRuntime;
    Spatial​Surface​Mesh​Buffer surfaceMeshBuffer = ...
    byte[] data = surfaceMeshBuffer.ToArray();
    var vectors = new List<Vector4>();    
    for(int i = 0; i < data.length; ) {
        float x  = System.BitConverter.ToSingle(data, i);
        i += surfaceMeshBuffer.Stride;
        float y  = System.BitConverter.ToSingle(data, i);        
        i += surfaceMeshBuffer.Stride;
        float z  = System.BitConverter.ToSingle(data, i);        
        i += surfaceMeshBuffer.Stride;
        float w  = System.BitConverter.ToSingle(data, i);        
        i += surfaceMeshBuffer.Stride; 
        vectors.Add(new Vector4(x, y, z, w));
    }
