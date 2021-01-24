    private Capture capture;
    private bool takeSnapshot = false;
    
    public Form1()
    {
        InitializeComponent();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        // Make sure we only initialize webcam capture if the capture element is still null
        if (capture == null)
        {
            try
            {
                // Start grabbing data, change the number if you want to use another camera
                capture = new Capture(0);
            }
            catch (NullReferenceException excpt)
            {
                // No camera has been found
                MessageBox.Show(excpt.Message);
            }
        }
    
        // This makes sure the image will be fitted into your picturebox
        originalImageContainer.SizeMode = PictureBoxSizeMode.StretchImage;
    
        // When the capture is initialized, start processing the images in the PorcessFrame method
        if (capture != null)
            Application.Idle += ProcessFrame;
    }
    
    // You registered this method, so whenever the application is Idle, this method will be called.
    // This allows you to process a new frame during that time.
    private void ProcessFrame(object sender, EventArgs arg)
    {
        // Get the newest webcam frame
        Image<Bgr, double> capturedImage = capture.QueryFrame();
        // Show it in your PictureBox. If you don't want to convert to Bitmap you should use an ImageBox (which is an EmguCV element)
        originalImageContainer.Image = capturedImage.ToBitmap();
    
        // If the button was clicked indicating you want a snapshot, save the image
        if(takeSnapshot)
        {
            // Save the image
            capturedImage.Save(@"C:\your\picture\path\image.jpg");
            // Set the bool to false again to make sure we only take one snapshot
            takeSnapshot = !takeSnapshot;
        }
    }
    
    //When clicking the save button
    private void SaveButton_Click(object sender, EventArgs e)
    {
        // Set the bool to true, so that on the next frame processing the frame will be saved
        takeSnapshot = !takeSnapshot;
    }
