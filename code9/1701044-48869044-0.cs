    Sometimes there is a need to insert, update and delete records in a GridView using a single Stored Procedure instead of creating separate Stored Procedures for each operation.
    
    Suppose I have one .aspx web page in which I need a to insert, view, update and delete records. To do that, instead of creating four Stored Procedures to perform these tasks I will create a single Stored Procedure to satisfy my requirements and I will access it in code behind depending on the action performed by the end user on a button click.
    
    I have written this article specially focusing on newcomers and anyone new wants to insert, update and delete records in a GridView using a Single Stored Procedure, so let us start with a basic introduction.
    
    First create the the table named employee as:
    I have set the primary key on the id column and I have set the Identity specification to Yes.
    
    Now we have a table to perform these operations for. Now let us start to create the Stored Procedure.
    
    The Stored Procedure is created using the keyword "Create Procedure" followed by the procedure name. Let us create the Stored Prcedure named "EmpEntry" as in the following:
    
    create Procedure EmpEntry
    (
      --variable  declareations 
     @Action Varchar (10),    --to perform operation according to string ed to this varible such as Insert,update,delete,select      
     @id int=null,    --id to perform specific task
     @FnameVarchar (50)=null,   -- for FirstName
     @MName Varchar (50)=null,   -- for MName
     @Lname Varchar (50)=null    -- for LastName
    )
    as
    Begin 
      SET NOCOUNT ON;
    
    If @Action='Insert'   --used to insert records
    Begin
       Insert Into employee (FirstName,MName,LastName)values(@Fname,@MName,@Lname)
    End  
    else if @Action='Select'   --used to Select records
    Begin
        select *from employee
    end
    else if @Action='Update'  --used to update records
    Begin
       update employeeset FirstName=@Fname,MName=@MName,LastName=@Lname where id=@id
     End
     Else If @Action='delete'  --used to delete records
     Begin
       delete from employeewhere id=@id
     end
     End
    
    The comments in the Stored Procedure above clearly explain which block is used for which purpose, so I have briefly explained it again. I have used the @Action variable and assigned the string to them and according to the parameter ed to the Stored Procedure the specific block will be executed because I have kept these blocks or conditions in nested if else if conditional statements.
    
    "The most important thing is that I have assigned null to each variable to avoid the effect on the parameter ed to the Stored Procedure because we are ing a different number of parameters but not the same number of parameters to the Stored Procedure to perform these tasks."
    
    Now create the one sample application "Empsys" as:
    
    "Start" - "All Programs" - "Microsoft Visual Studio 2010".
    "File" - "New Project" - "C#" - "Empty Web Application" (to avoid adding a master page).
    Provide the web site a name such as  "Empsys" or another as you wish and specify the location.
    Then right-click on Solution Explorer - "Add New Item" - "Default.aspx page".
    Drag and drop one button, three textboxes, one GridView and one hidden field to the hidden value to the database and one label on the <form> section of the Default.aspx page.
    Then switch to the design view; the <form> section of the Default aspx page source will look as in the following:
     
    <form id="form1"runat="server">
        <div>
    First Name  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    Middle Name<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    Last Name <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:ButtonID="Button1"runat="server"Text="save"onclick="Button1_Click" />
        </div>
    <asp:HiddenField ID="HiddenField1" runat="server"/>
     <asp:GridViewID="GridView1"runat="server" >
         </asp:GridView>
    </form>
    
    Now use the following GridView event properties to perform events such as update, delete, edit cancel and so on. Let us see what the properties are:
    
    DataKeyNames: This property I have used to the the row index of GridView  
    OnRowEditing: This property is used to handle the event when the user clicks on the edit button
    OnRowCancelingEdit: This property is used to handle the event when the user clicks on the Cancel button that exists after clicking on the edit button
    OnRowDeleting: This property is used to handle the event when the user clicks on the delete button that deletes the row of the GridView
    OnRowUpdating: This property is used to handle the event when the user clicks on the update button that updates the Grid Record 
    Now my grid will look such as the following:
    
    <asp:GridViewID="GridView1" runat="server" DataKeyNames ="id"OnRowEditing ="Edit"               
            OnRowCancelingEdit ="canceledit"    OnRowDeleting ="delete"    OnRowUpdating = "Update" >
     </asp:GridView>
    
    On the preceding GridView properties I have assigned the method name to be called for particular operations.
    
    Method to Insert Data in Database  
    
    Right-click from the design page and view the code and then write the following code in the default.aspx.cs page to save the inserted records in the database:
    protected void empsave(object sender, EventArgs e)
    {
          connection();
          query =  "studentEntryView";          //Stored Procedure name 
          SqlCommand com = new SqlCommand(query, con);  //creating  SqlCommand  object
          com.CommandType = CommandType.StoredProcedure;  //here we declaring command type as stored Procedure
    
           /* adding paramerters to  SqlCommand below *\
          com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();//for ing hidden value to preform insert operation
           com.Parameters.AddWithValue("@FName",TextBox1.Text.ToString());        //first Name
           com.Parameters.AddWithValue("@Mname ", TextBox2.Text.ToString());     //middle Name
           com.Parameters.AddWithValue("@LName ",TextBox3.Text.ToString());       //Last Name
           com.ExecuteNonQuery();                     //executing the sqlcommand
           Label1.Visible = true;
           Label1.Text = "Records are Submitted Successfully";
    }
    
    Now create the mehtod to view the records in the GridView:
    
    public void viewdata()
    
    {
        connection();
        query = "studentEntryView";
        SqlCommand com = new SqlCommand(query, con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@Action", HiddenField2.Value).ToString();
        DataSet ds =new DataSet();
        SqlDataAdapter da =  new SqlDataAdapter(com);
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    The following is method for the "OnRowEditing" Event:
    
    protected void edit(objectsender, GridViewEditEventArgs e)
    
    {
    
        GridView1.EditIndex= e.NewEditIndex;
    
        gedata();
    
    }
    
    The following is method for the "OnRowCancelingEdit" Event:
    
    protected void  canceledit(object sender, GridViewCancelEditEventArgs e)
    
    {
    
        GridView1.EditIndex = -1;
    
        gedata();
    
    }
    
    The following is method for the "OnRowDeleting" Event:
     
    
    protected void delete(object sender, GridViewDeleteEventArgs e)
    
    {
    
          connection();
    
          int id =  int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
    
          HiddenField1.Value = "Delete";
    
          query = "EmpEntry";
    
          com = new SqlCommand(query, con);
    
          com.CommandType =CommandType .StoredProcedure;
    
          com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
    
          com.Parameters.AddWithValue("id", SqlDbType.Int).Value = id;
    
          com.ExecuteNonQuery();
    
          con.Close();
    
          gedata();                 
    
     }
     
    
    The following is method for the "OnRowUpdating" Event:
     
    protected void update(object sender, GridViewUpdateEventArgs e)
    
    {
    
         connection();
    
         int id=int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
    
         HiddenField1.Value = "update";
    
         query = "EmpEntry";
    
         com = new SqlCommand(query, con);
    
         com.CommandType = CommandType.StoredProcedure;
    
         com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
    
         com.Parameters.AddWithValue("@FName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString());
    
         com.Parameters.AddWithValue("@MName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString());
    
         com.Parameters.AddWithValue("@LName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString());
    
         com.Parameters.AddWithValue("@id", SqlDbType.int ).Value = id;
    
         com.ExecuteNonQuery();
    
         con.Close();
    
         GridView1.EditIndex = -1;
    
         gedata();
    
           
    
    }
    
    Brief introduction to the code
    
    In the sample code above I have used the two string queries for giving the Stored Procedure name and the constr for storing the connection from the web.config file and another thing is that I have used a hidden field by which I am ing the action values that are required to our Stored Procedure.
    
    Now our application is ready to use, press F5 or other as you know, then enter the some values to TextBox and press the "Save" button.
    
    Now after clicking on the "Save" button, the hidden field value takes the value "Insert" and es it to the Stored Procedure as the action and because of this the Stored Procedure will execute a particular type of block.
    
    Now at page load I have called the method, so after that the grid will fill as in:
    
    Now click on the Edit button that calls the edit method as shown in the following grid:
    
    If you click on the "Cancel" button then the editcancel method will be called and edit mode will be cancelled. Now enter some values into the grid TextBox and click on an update button that calls the update method and then the records in the GridView will be updated as in:
    
    Now click on the delete button that calls the delete method and deletes the records from the GridView
     
    
    Note
    For detailed code please download the zip file attached above.
    Don't forget to update the Web.config file for your server location. 
