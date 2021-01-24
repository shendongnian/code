     if ((e.Row.RowState & DataControlRowState.Edit) == 0)
            {
                CheckBoxList c = (CheckBoxList)e.Row.FindControl("CheckBoxList2");
                CheckBoxList CheckBoxListDR = (CheckBoxList)e.Row.FindControl("CheckBoxList3");
                DataTable dt;
                String SQL = "SELECT distinct S.Steps, D.DocumentsRequired, T.TransactionID FROM [StepsIsSelectedTable] S JOIN TransactionDetail T " +
                    " ON S.TransactionIDSteps = T.TransactionID JOIN DocumentsRequiredIsSelected D " +
                    "ON D.TransactionIDDR = T.TransactionID  WHERE " +
                    "TransactionIDDR ='" + TreeView1.SelectedValue + "' and S.StepsIsSelected='True' and D.DocumentsRequiredIsSelected='True'" +
                    " group by S.Steps, D.DocumentsRequired ,T.TransactionID";
                string sConstr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(sConstr))
                {
                    using (SqlCommand comm = new SqlCommand(SQL, conn))
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(comm))
                        {
                            dt = new DataTable("tbl");
                            da.Fill(dt);
                        }
                    }
                    c.DataSource = dt;
                    CheckBoxListDR.DataSource = dt;
                    c.DataTextField = "Steps";
                    c.DataValueField = "TransactionID";
                    CheckBoxListDR.DataTextField = "DocumentsRequired";
                    CheckBoxListDR.DataValueField = "TransactionID";
                    c.DataBind();
                    c.SelectedValue = "TransactionID";
                    CheckBoxListDR.DataBind();
                    CheckBoxListDR.SelectedValue = "1";
                }
            }
 
