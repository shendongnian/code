     int postID;
     string fbGroupID;
     int listID = int.Parse(cmbSelectList.SelectedValue.ToString());
 
     using (OleDbConnection connection = new OleDbConnection(conn))
     {
      ................
           commName.CommandText = "SELECT TOP 1 [FaceBookGroupID],[PostID] FROM [Advertiseing] WHERE [email] = @email AND [ListForGroupID]= @listID ORDER BY [Date-Time] DESC";
      ................
           postID = list[0].PostID;
           fbGroupID = list[0].FBGroupID;        
           *listID = list[0].ListForGroupID;* //Deleted
      }
      //cmbSelectList.SelectedValue = listID; - Deleted
        cmbSavedPosts.SelectedValue = postID;
      //loadGroupsInList(); - Deleted
      // Next part of code are the same
      ................
