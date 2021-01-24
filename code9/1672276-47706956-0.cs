    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Roll No query string cannot be null
                if (Request["RollNo"] != null)
                {
                    //Check Roll No cannot exeed 6 digits
                    if (Request["RollNo"].Length <= 6)
                    {
                        string RollNo = Request["RollNo"];
    
                        //Check Roll No. must be all digits
                        int iRollNo;
                        if (Int32.TryParse(RollNo, out iRollNo))
                        {
                            //Prefix with zero for RollNo less than 6 digits
                            if (RollNo.Length < 6)
                            {
                                RollNo = new String('0', 6 - RollNo.Length) + RollNo;
                            }
    
                            //Display 6 images
                            Image1.ImageUrl = "~/Number/" + RollNo[0] + ".png";
                            Image2.ImageUrl = "~/Number/" + RollNo[1] + ".png";
                            Image3.ImageUrl = "~/Number/" + RollNo[2] + ".png";
                            Image4.ImageUrl = "~/Number/" + RollNo[3] + ".png";
                            Image5.ImageUrl = "~/Number/" + RollNo[4] + ".png";
                            Image6.ImageUrl = "~/Number/" + RollNo[5] + ".png";
                        }
                    }
                }
            }
        }
