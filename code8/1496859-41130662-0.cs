    using System;
    using System.Collections.Generic;
    
    namespace TestIt
    {
        public partial class Form1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                FillTheList();
            }
    
            private void FillTheList()
            {
                ddl_TheList.Items.Clear();
                ddl_TheList.DataSource = UsStates;
                ddl_TheList.DataTextField = "statename";
                ddl_TheList.DataValueField = "stateStatus";
                //ddl_TheList.Items.Insert(0, String.Empty);
                ddl_TheList.DataBind();
                ddl_TheList.SelectedIndex = 0;
            }
    
            private IEnumerable<IStateItem> UsStates
            {
                get
                {
                    List<IStateItem> usStates = new List<IStateItem>();
                    for (int i = 0; i < 10; i++)
                    {
                        usStates.Add(new IStateItem { statename = "state #" + i, stateStatus = "cool state bro" });
                    }
                    return usStates;
                }
            }
        }
    
        public class IStateItem
        {
            public string statename { get; set; }
            public string stateStatus { get; set; }
        }
    
    
    }
