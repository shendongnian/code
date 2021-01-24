    public class Camera
    {
       public void Connect(){}
       public void Disconnect(){}
       // common methods for cameras
    }
    public class VendorXCamera: Camera
    {
       private VendorX_SDK_object sdk_object;
    }
    public class VendorYCamera: Camera
    {
       private VendorY_SDK_object sdk_object;
    }
