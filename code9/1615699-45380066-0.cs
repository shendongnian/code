    using System;
    
    namespace PersistingCheckboxes_45379633
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                    /*
                     * This is a postback, therefore I want to populate the page according to what's in the database
                     */
                    txtbx_1.Text = "postback";
                    chkbx_item1.Checked = WhatDoesTheDBSay(1);
                    chkbx_item2.Checked = WhatDoesTheDBSay(2);
                }
                else
                {
                    /*
                     * This is not a postback, so we initialize the fields
                     */
                    txtbx_1.Text = "not a postback";
                    chkbx_item1.Checked = false;
                }
            }
    
            private bool WhatDoesTheDBSay(int fieldID)
            {
                if (fieldID == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
     
        }
    }
