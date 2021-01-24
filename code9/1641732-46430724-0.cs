    private CascadeClassifier _cascadeClassifier;
    _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt_tree.xml");
    using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
                    {
                        if (imageFrame != null)
                        {
                            var grayframe = imageFrame.Convert<Gray, byte>();
                            var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                        
    foreach (var face in faces)
                        {
                            imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                           
                        }
                    }
                    imgCamUser.Image = imageFrame;                    
                }
