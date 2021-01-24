    using Ext.Net;
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UC")]
    public partial class SampleUserCtlClass : System.Web.UI.UserControl
    {
        [DirectMethod]
        public void DoYes()
        {
            X.Msg.Alert("Message", "Hello from UserControl").Show();
        }
    }
