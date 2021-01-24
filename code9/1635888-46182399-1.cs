    protected void btn_approve_Click(object sender, EventArgs e)
            {
                try
                {
                    if (hf_outgoingId.Value != null)
                    {
                        var abc = (from a in db.Outgoings
                                   where a.OutgoingID == Convert.ToInt32(hf_outgoingId.Value)
                                   select a).FirstOrDefault();
                        abc.Status = "APPROVED";
                        db.SubmitChanges();
    
                        gridview.DataBind();
                        ModalPopupExtender1.Hide();
                        ModalAlertSuccess.Show();
                    }
                }
                catch (Exception x)
                {
    
                }
    
    
            }
