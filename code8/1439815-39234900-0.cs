    protected void btnSubmit_Click(object sender, EventArgs e)
            {
                if (!IsPostBack) 
                {
                    Validate();
                    update(txtFirstName.Text,
                                      txtLastName.Text,
                                      txtEmail.Text,
                                      txtNumber.Text,
                                      DropDownList1.SelectedItem.Text,
                                      txtMessage.Text);
                    Response.Write("Record was successfully added!");
                    //ClearForm(Page);
                } 
                else Response.Write("Postback");
            }
