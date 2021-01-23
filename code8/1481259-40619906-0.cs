     decimal salaryGrade;  
      sqc = con.CreateCommand();
            string query5 = "SELECT [SalaryGrade] FROM tbl_gradestep where GradeNumber =" + cmbGradeNumber.SelectedItem.ToString() + " and StepNumber =" + cmbStepNumber.SelectedItem.ToString() + "";
            sqc.CommandText = query5;
            sda = new SqlDataAdapter(sqc);
            dt = new DataSet();
            sda.Fill(dt);
            if(dt.Tables[0].Rows.Count > 0)
            {
                lblSalary.Text = dt.Tables[0].Rows[0]["SalaryGrade"].ToString();                     
                if (decimal.TryParse(dt.Tables[0].Rows[0]["SalaryGrade"].ToString(), out salaryGrade))
                {
                  
                }
               lblHour.Text = Convert.ToDecimal(salaryGrade / 22 / 8).ToString("0.00");
               
            }
            
            con.Close();
        }
