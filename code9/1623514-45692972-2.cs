    public partial class Register : MaterialForm
        {
            //Declare my UnitOfwORK
            private readonly UnitOfWork _unitOfWork;
    
            string userName;
            string psswrd;
            string Confirmpsswrd;
           
    
            //I Inject IUnitOfOfClass with the Help of Simple Injector dependency injection library
            public Register(UnitOfWork unitOfWork)
            {
                InitializeComponent();
                //Set your preferred colors &theme (Material Skin)
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Red900, Primary.Brown900, Accent.LightBlue200, TextShade.BLACK);
                //prevent Form from Resizing 
                Sizable = false;
    
                _unitOfWork = unitOfWork;
            }
    
            private void SetUnitOfWork()
            {
    
            }
            private void Register_Load(object sender, EventArgs e)
            {
    
            }
    
            private void btnSubmit_Click(object sender, EventArgs e)
            {
                //Get the User email and Password to register in the DB
                userName = textEmail.Text;
                psswrd = textPassword.Text;
                Confirmpsswrd = textConfirmPassword.Text;
                //Compare the password
                bool conRes = ComparePassword(psswrd, Confirmpsswrd);
                if (conRes)
                {
                    //Insert to db using the UnitOfWork
                    UserPass userToDb = new UserPass
                    {
                        UserName = this.userName,
                        password = this.psswrd,
                        LastAcess = DateTime.Now
    
                    };
    
                   _unitOfWork.UserPasses.Add(userToDb);
                    //Commit calling complete()
                   _unitOfWork.Complete();
                    //FeedBack Registered Sucessfull
                    LabelErrorPassword.Text = "Successful, Login!";
                }
                else
                {
                    LabelErrorPassword.BackColor = Color.Red;
                    LabelErrorPassword.Text = "The Passwords don't match!"; //show in the Label that password are not the same
                }
            }
    
    
            /**********Method to compare Password**********************/
            public bool ComparePassword(string pss1, string pss2)
            {
                if (pss1.Equals(pss2))
                {
                    return true;
                }
                else return false;
            }
        }
