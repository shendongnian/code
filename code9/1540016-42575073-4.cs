    public Form1()
    {
          InitializeComponent();  
          picContainer.Controls.Add(new MyPictureClass()
          {
                Image = imageList1.Images[0],
          }
         );
    }
