    public interface ICamera{
       void Connect();
       void Disconnect();
    }
    abstract class CameraBase:ICamera
    {
       protected abstract void OpenStream();
       protected abstract void CloseStream();
       public void Connect(){
          Debug.WriteLine("connecting");
          OpenStream();
          Debug.WriteLine("connected");
       }
       public void Disconnect(){
          Debug.WriteLine("connecting");
          CloseStream();
          Debug.WriteLine("connected");
       }
    }
    class VendorXCamera: CameraBase
    {
       private VendorX_SDK_object vendorx_sdk_object;
       protected override void OpenStream(){
          vendorx_sdk_object.OpenStream(..);
       }
       protected override void CloseStream(){
          vendorx_sdk_object.CloseStream(..);
       }
    }
    class VendorYCamera: CameraBase
    {
       private VendorY_SDK_object vendory_sdk_object;
       protected override void OpenStream(){
          vendory_sdk_object.OpenStream(..);
       }
       protected override void CloseStream(){
          vendory_sdk_object.CloseStream(..);
       }
    }
