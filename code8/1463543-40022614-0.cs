    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using WebCam_Capture;
    using System.Collections.Generic;
    namespace controlPC{
     class WebCam{
    private WebCamCapture webcam;
    private System.Windows.Forms.PictureBox _FrameImage;
    private int FrameNumber = 50;
     public void InitializeWebCam(ref System.Windows.Forms.PictureBox ImageControl){
     webcam = new WebCamCapture();
      webcam.FrameNumber = ((ulong)(0ul));
     webcam.TimeToCapture_milliseconds = FrameNumber;
     webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
    _FrameImage = ImageControl;}
     void webcam_ImageCaptured(object source, WebcamEventArgs e){
     _FrameImage.Image = e.WebCamImage;}
      public void Start(){
     webcam.TimeToCapture_milliseconds = FrameNumber;
     webcam.Start(0);}
     public void Stop(){
     webcam.Stop();}
     public void Continue(){
     webcam.TimeToCapture_milliseconds = FrameNumber;
     webcam.Start(this.webcam.FrameNumber);}
 
