    namespace ProjectName.Folder.Custom_Webpart
    {
        [ToolboxItemAttribute(false)]
        public class Custom_Webpart : System.Web.UI.WebControls.WebParts.WebPart
        {
            private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/ProjectName/Folder/Custom_UserControl.ascx";
    
            protected override void CreateChildControls()
            {
                var control = Page.LoadControl(_ascxPath) as Custom_UserControl;
                //this.ChromeType = PartChromeType.None;
                Controls.Add(control);
            }
        }
    }
