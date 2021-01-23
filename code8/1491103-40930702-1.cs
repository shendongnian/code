            string divisions = string.empty ; 
         foreach(ListItem item in Divisions)
                {
               divisions  = divisions  + item.Value.tostring() + ",";
                }
        
        if (divisions != string.empty)
      { 
        divisions = divisions.Remove(divisions.Length -1, 1)
         string GetCourses = "SELECT distinct Course_Code,Course_Code + ' - ' + Marketing_Title AS COURSE, Parent FROM e_prospectus 
        WHERE (Div in (" + divisions + ")) ORDER BY Course_Code";
                    cbCourseSelect.DataSource = GetData(GetCourses);
                    cbCourseSelect.DataTextField = "COURSE";
                    cbCourseSelect.DataValueField = "Course_Code";
                    cbCourseSelect.DataBind();
        }
