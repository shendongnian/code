    DataKeyNames: This property I have used to the the row index of GridView  
    OnRowEditing: This property is used to handle the event when the user clicks on the edit button
    OnRowCancelingEdit: This property is used to handle the event when the user clicks on the Cancel button that exists after clicking on the edit button
    OnRowDeleting: This property is used to handle the event when the user clicks on the delete button that deletes the row of the GridView
    OnRowUpdating: This property is used to handle the event when the user clicks on the update button that updates the Grid Record 
    Now my grid will look such as the following:
    
    <asp:GridViewID="GridView1" runat="server" DataKeyNames ="id"OnRowEditing ="Edit"               
            OnRowCancelingEdit ="canceledit"    OnRowDeleting ="delete"    OnRowUpdating = "Update" >
     </asp:GridView>
    
