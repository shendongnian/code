        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string result = string.Empty;
                Page.Validate();
                if (!Page.IsValid)
                { return; }
                result = new C_OPDRegistration().Set_OPDReg(inputName.Value,
                                                               inputAge.Value,
                                                               male.Checked ? 1 : 2,
                                                               inputContact.Value,
                                                               inputAddress.Value,
                                                               "user",
                                                               "1",
                                                               DDL_type.SelectedValue
                                                           );
                if (result != null)
                {
                    List<dataObject> list = new List<CapronCRM.dataObject>()
                    {
                     new dataObject()
                     {
                         InputName =  inputName.Value,
                         InputAge = inputAge.Value,
                         Gender = male.Checked ? "MALE" : "FEMALE",
                         InputContact = inputContact.Value,
                         InputAddress = inputAddress.Value,
                         Type =  "user",
                   SelectedItemText = DDL_type.SelectedItem.ToString()
                    }
                };
                   DisplayOPD(list);
                   return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
