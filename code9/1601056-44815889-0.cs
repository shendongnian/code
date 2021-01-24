    private void DeleteEdit()
    {
        Control[] EmployeesControl; //I think this is the problem, but i cant figure it out.
    
        if (Form_AddEmployee.Text.Contains("Edit"))
        {
            EmployeesControl = new RadioButton[numberOfEmployees];
        }
        else if (Form_AddEmployee.Text.Contains("Delete"))
        {
            EmployeesControl = new CheckBox[numberOfEmployees];
        }
    
        CheckBox chk;
        RadioButton rdo;
        for (int i = 0; i < EmployeesControl.Count(); i++)
        {
            if (EmployeesControl[i].GetType() == typeof(RadioButton))
            {
                rdo = (RadioButton)EmployeesControl[i];
    
                //Your code
                //................
                rdo.CheckedChanged += EmployeesDeleteEditEmployees_CheckedChanged;                    
            }
            else
            {
                chk = (RadioButton)EmployeesControl[i];
    
                //Your code
                //...............
                chk.CheckedChanged += EmployeesDeleteEditEmployees_CheckedChanged;
            }
    
            //EmployeesControl[i] = new EmployeesControl();
            //InitializeControls(EmployeesControl[i]);
            //EmployeesControl[i].Visible = true;
            //panelEmployee.Controls.Add(EmployeesControl[i]);
            //EmployeesControl[i].Text = stringTemp;
            //EmployeesControl[i].Location = new Point(100, 100 * (i + 1));
            //EmployeesControl[i].Font = MyFont;
            //EmployeesControl[i].CheckedChanged += EmployeesDeleteEditEmployees_CheckedChanged;                      
        }
    }
