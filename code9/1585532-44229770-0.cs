    using System.Runtime.InteropServices.WindowsRuntime;
    Spatial​Surface​Mesh​Buffer surfaceMeshBuffer = ...
    byte[] data = surfaceMeshBuffer.ToArray();
    
    for(int i = 0; i < data.length; ) {
        float x  = System.BitConverter.ToSingle(mybyteArray, i);
        i += surfaceMeshBuffer.Stride;
        float y  = System.BitConverter.ToSingle(mybyteArray, i);        
        i += surfaceMeshBuffer.Stride;
        float z  = System.BitConverter.ToSingle(mybyteArray, i);        
        i += surfaceMeshBuffer.Stride;
        float w  = System.BitConverter.ToSingle(mybyteArray, i);        
        i += surfaceMeshBuffer.Stride; 
    }
