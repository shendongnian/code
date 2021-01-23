    public void Page_Load(object sender, EventArgs e)
    {
     // if (IsPostBack)
    //  {
    //    return;
     // } 
       try    {         
    if (Session["user"] == null || Request.QueryString["applicationID"] == null)
        {
            throw new Exception("Invalid Session. Please login again!");
        }
        Application1 appRow = bal.GetApplication(ApplicationID)[0];
        PanelQuickJump.Visible = Boolean.Parse(Session["IsAdmin"].ToString()) && (TaskID == 9 || TaskID == 25 || TaskID == 33 || TaskID == 55) && (appRow.ApplicationClosed != true);            
        ImageButtonSearch.Attributes.Add("onclick", "window.open ('SearchPop.aspx',null,'scrollbars=yes, status= no, resizable = yes, toolbar=no,location=no,height = 700, width = 1200, left = 200, top= 200, screenx=10,screeny=600,menubar=no');");
        /* get task */
        activeTask = bal.GetActiveTask(ApplicationID, Employee.EmployeeID)[0];
        //applicant = employeeAdapter.GetApplicant(ApplicationID)[0];
        LabelTaskName.Text = activeTask.Task;
        /* get menu items */
        List<TaskForm1> taskForms = bal.GetTaskFormByTask(activeTask.TaskID, activeTask.SubTaskID);
            foreach (TaskForm1 row in taskForms)
        {
            li = new HtmlGenericControl("li");
            anchor = new HtmlGenericControl("a");
            string itemURL = row.Page + "?applicationID=" + ApplicationID;              
            if (row.Checkable == true)
            {
                string reqMenuItem = "<span style=\"color: #669900; font-weight: bold\">" + row.Title + "</span>";
                anchor.InnerText = reqMenuItem;
                anchor.Attributes.Add("href", itemURL);                                
            }
            else
            {
                anchor.Attributes.Add("href", itemURL);
                anchor.InnerText = row.Title ;
            }
            if (row.Page == CurrentPageName)
            {
                anchor.InnerText =  row.Title ;
            }
            li.Controls.Add(anchor);
            Menu.Controls.Add(li);
     }
    }
