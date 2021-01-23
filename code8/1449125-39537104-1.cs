        public partial class Exception1 : System.Web.UI.Page
    {
        protected DeviceDetails deviceDetails;
        protected void Page_Load(object sender, EventArgs e)
        {
             deviceDetails = new DeviceDetails("Test", "My Test");
            
        }
    }
    public class DeviceDetails
    {
        public string Name { get; set; }
        public string FailureDetails { get; set; }
        public DeviceDetails(string name, string description)
        {
            Name = name;
            FailureDetails = description;
        }
    }
