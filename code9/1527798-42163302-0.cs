    <script >
        function myModalFunction() {
            $("#AddTask").modal();
        } </script>
    // method to trigger an jsFunction
    public void dispararJSfunction(string script)
    {
        try
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "its working", script, true);
        }
        catch (Exception ex) { Master.MostrarMsn(ex.Message, 0); }
    }
    protected void imgAppointment_Click(object sender, EventArgs e)
    {
    
    	// script = the js modal function
    	dispararJSfunction("myModalFunction()");
    
        CommandEventArgs commandArgs = new CommandEventArgs("Command Name Here", "Your Command Argument Here");
        //You can pass any row
        //You can also skip the row parameter and get the row from Command Argument
        GridViewCommandEventArgs eventArgs = new GridViewCommandEventArgs(GridView1.Rows[0], GridView1, commandArgs);
        GridView1_RowCommand(GridView1, eventArgs);
    } 
