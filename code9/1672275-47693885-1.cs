    protected void Page_Load(object sender, EventArgs e)
            {
                // This happens whenever there is a rollno variable coming in from the querystring
                if (Request.QueryString["RollNo"] != null)
                {
                    string RollNo = Request.QueryString["RollNo"];                
                    ShowImages(RollNo);
                }
            }
    
            // this happens when you enter the roll numbers in the text box and hit the send button
            protected void Button1_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(RollNo.Text))
                {
                    LBLRollNo.Text = " Selected roll numbers" + RollNo.Text;
                    ShowImages(RollNo.Text);
                }
            }
    
            // Roll variable is the roll number. Imageno is the image number inside each Roll. And this information is stored in the image ID attribute.
            protected void ShowImages(string RollNumbers)
            {
                LBLRollNo.Text = " Selected roll numbers" + RollNumbers;
                var rollNoArray = RollNumbers.Select(t => int.Parse(t.ToString())).ToArray();
    
                foreach (int rollno in rollNoArray)
                {
                    // add a HTML newline, just to make it more neat
                    Literal templiteral = new Literal();
                    templiteral.Text = "<br/>";
                    ImagePanel.Controls.Add(templiteral);
    
                    Label templabel = new Label();
                    templabel.Text = "Images in roll number " + rollno.ToString();
                    ImagePanel.Controls.Add(templabel);
                    
                    // Lay out the images belonging to this roll number (rollno)
                    for (int Imageno = 0; Imageno <= 5; Imageno++)
                    {
                        string identity = "ident|" + rollno.ToString() + "|" + Imageno.ToString() + "|"; // The IDs of each image on-screen will bear an ID like this: ident|0_0|
                        Image tempimage = new Image();
                        tempimage.ID = identity;
                        ImagePanel.Controls.Add(tempimage);
                    }
                }
            }
    
            // This routine lays out all rolls and images in one go
            protected void LayOutImages()
            {
                for (int Roll = 0; Roll <= 10; Roll++)
                {
                    Label templabel = new Label();
                    templabel.Text = "Roll number " + Roll.ToString();
                    ImagePanel.Controls.Add(templabel);
    
                    for (int Imageno = 0; Imageno <= 5; Imageno++)
                    {
                        string identity = "ident|" + Roll.ToString() + "|" + Imageno.ToString() + "|"; // The IDs of each image on-screen will bear an ID like this: ident|0_0|
                        Image tempimage = new Image();
                        tempimage.ID = identity;
                        ImagePanel.Controls.Add(tempimage);
                    }
                    Literal templiteral = new Literal();
                    templiteral.Text = "<br/>";
                    ImagePanel.Controls.Add(templiteral);
                }
            }
