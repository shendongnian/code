    private void SetPreviousDataLecturer()
    {
        int rowIndex = 0;
        if (ViewState["LecturerGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 0; i < dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxLName = (TextBox)LecturerGridView.Rows[rowIndex].Cells[1].FindControl("LecturerName");
                    TextBox textBoxLID = (TextBox)LecturerGridView.Rows[rowIndex].Cells[2].FindControl("LecturerID");
                    TextBox textBoxLAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[3].FindControl("LecturerAddress");
                    TextBox textBoxLPNumber = (TextBox)LecturerGridView.Rows[rowIndex].Cells[4].FindControl("LecturerPNumber");
                    TextBox textBoxLEAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[5].FindControl("LecturerEAddress");
                    CheckBoxList checkBoxListLCourse = (CheckBoxList)LecturerGridView.Rows[rowIndex].Cells[6].FindControl("LecturerCourse");
                    TextBox textBoxLPassword = (TextBox)LecturerGridView.Rows[rowIndex].Cells[7].FindControl("LecturerPassword");
                    LecturerGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    textBoxLName.Text = dataTableCurrent.Rows[i]["LecturerName"].ToString();
                    textBoxLID.Text = dataTableCurrent.Rows[i]["LecturerID"].ToString();
                    textBoxLAdd.Text = dataTableCurrent.Rows[i]["LecturerAddress"].ToString();
                    textBoxLPNumber.Text = dataTableCurrent.Rows[i]["LecturerPNumber"].ToString();
                    textBoxLEAdd.Text = dataTableCurrent.Rows[i]["LecturerEAddress"].ToString();
                    checkBoxListLCourse.Text = dataTableCurrent.Rows[i]["LecturerCourse"].ToString();
                    string lecturerCourse = dataTableCurrent.Rows[i]["LecturerCourse"].ToString();
                    if (!string.IsNullOrEmpty(lecturerCourse))
                    {
                        for (int j = 0; j < lecturerCourse.Split(',').Length; j++)
                        {
                            checkBoxListLCourse.Items.FindByValue(lecturerCourse.Split(',')[j].ToString()).Selected = true;
                        }
                    }
                    textBoxLPassword.Text = dataTableCurrent.Rows[i]["LecturerPassword"].ToString();
                    rowIndex++;
                }
            }
        }
    }
    private void AddNewRowToLecturerGV()
    {
        int rowIndex = 0;
        if (ViewState["LecturerGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxLName = (TextBox)LecturerGridView.Rows[rowIndex].Cells[1].FindControl("LecturerName");
                    TextBox textBoxLID = (TextBox)LecturerGridView.Rows[rowIndex].Cells[2].FindControl("LecturerID");
                    TextBox textBoxLAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[3].FindControl("LecturerAddress");
                    TextBox textBoxLPNumber = (TextBox)LecturerGridView.Rows[rowIndex].Cells[4].FindControl("LecturerPNumber");
                    TextBox textBoxLEAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[5].FindControl("LecturerEAddress");
                    CheckBoxList checkBoxListLCourse = (CheckBoxList)LecturerGridView.Rows[rowIndex].Cells[6].FindControl("LecturerCourse");
                    TextBox textBoxLPassword = (TextBox)LecturerGridView.Rows[rowIndex].Cells[7].FindControl("LecturerPassword");
                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["LecturerName"] = textBoxLName.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerID"] = textBoxLID.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerAddress"] = textBoxLAdd.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerPNumber"] = textBoxLPNumber.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerEAddress"] = textBoxLEAdd.Text;
                    string lecturerCourse = string.Empty;
                    foreach (ListItem item in checkBoxListLCourse.Items)
                    {
                        if (item.Selected)
                        {
                            if (!string.IsNullOrEmpty(lecturerCourse))
                            {
                                lecturerCourse += ",";
                            }
                            lecturerCourse += item.Value;
                        }
                    }
                    dataTableCurrent.Rows[i - 1]["LecturerCourse"] = lecturerCourse;
                    dataTableCurrent.Rows[i - 1]["LecturerPassword"] = textBoxLPassword.Text;
                    rowIndex++;
                }
                dataTableCurrent.Rows.Add(dataRowCurrent);
                ViewState["LecturerGridView"] = dataTableCurrent;
                LecturerGridView.DataSource = dataTableCurrent;
                LecturerGridView.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
        SetPreviousDataLecturer();
    }
