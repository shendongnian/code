    public class MyPixel{
      public float X{
                    get{ /* access an array or 
                            array of structs or 
                            unmanaged memory */} 
                    set{ /* same */}
      }
      
      // for unrolled loops
      public static void BatchUpdateXY(float[] source,int pixelStart,int pixelEnd)
      { /* copy from source */}
    }
