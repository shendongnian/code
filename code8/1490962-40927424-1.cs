    public partial class frmUser : FormBase<User>
    {
        public frmUser()
        {
            InitializeComponent();
            User user = this.DbSet.FirstOrDefault(); // Get first user record
            user.Name = "New Name"; // Set new name value
            this.UpdateEntry(user); // Inform DbContext that user has changed
            this.SaveData(); // Save the changes made to the DbContext
        }
    }
