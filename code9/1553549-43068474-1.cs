    System.Web.UI.WebControls.Button btnSubmit = new System.Web.UI.WebControls.Button();
    btnSubmit.ID = "btnSubmit";
    btnSubmit.Text = "Click Here";
    btnSubmit.Click += getdata(); //wire up event
    //assuming, TextPreview is a Panel or someting
    TextPreview.Controls.Add(btnSubmit);
