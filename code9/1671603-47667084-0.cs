	public class CapturingCamera : AVCapturePhotoCaptureDelegate, ICapturingCamera
	{
        // Implement your ICapturingCamera interface methods...
		public override void DidFinishProcessingPhoto(AVCapturePhotoOutput output, AVCapturePhoto photo, NSError error)
		{
           ~~~
		}
    }
