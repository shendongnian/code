    int employeeID = 0;
    foreach (GridViewRow row in gridViewEmployee.Rows)
    {
        string curStr = row.Cells[0].ToString();
        int curID = 0;
        if (int.TryParse(curStr, curID)){
            if (employeeID < curID)
            {
                employeeID = curID);
            }
        }
    }
    employeeID++;
