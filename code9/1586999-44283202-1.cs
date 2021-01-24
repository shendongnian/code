    using CMS.DataEngine;
    using DE=CMS.DocumentEngine;
    
    namespace Fort.CMS.CMSPages
    {
        public partial class CreatePage : System.Web.UI.Page
        {
            #region "Variables"
    
            private DE.TreeNode mNode;
            private TreeProvider mTree;
