        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        
        public partial class Default4 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                PlaceHolder1.Controls.Add(GetRadioButtonList("RadioButtonList1"));
            }
            private RadioButtonList GetRadioButtonList(string ControlID)
            {
                RadioButtonList rbl = new RadioButtonList();
                rbl.Items.AddRange(
                    new ListItem[] {
                                new ListItem("Item 1", "1"),
                                new ListItem("Item 2", "2"),
                                new ListItem("Item 3", "3"),
                                new ListItem("Item 4", "4"),
                                new ListItem("Item 5", "5"),
                                new ListItem("Item 6", "6"),
                                new ListItem("Item 7", "7"),
                                new ListItem("Item 8", "8"),
                                new ListItem("Item 9", "9"),
                                new ListItem("Item 10", "10")
                        });
                rbl.ID = ControlID;
                return rbl;
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
               
                RadioButtonList rbl = (RadioButtonList)PlaceHolder1.FindControl("RadioButtonList1");
                Response.Write(rbl.SelectedValue);
        
            }
        
        }
    
    
    Use  ->PlaceHolder1.FindControl("RadioButtonList1");
