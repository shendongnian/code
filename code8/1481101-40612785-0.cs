    DataTable dt = new DataTable();
    DataTable edt = new DataTable();
    
    using (Conn)
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT QuestionID, Images2.ImageID, ImageFile, ImageContent, ImageName, SEQ_NUM from qimages join Images2 on qimages.imageid = images2.imageid where QuestionID = @QuestionID", Conn);
        ad.SelectCommand.Parameters.Add("QuestionID", SqlDbType.BigInt).Value = Convert.ToInt32(Request["Id"]);
        ad.Fill(dt);
        SqlDataAdapter ed = new SqlDataAdapter("SELECT QuestionID, Images2.ImageID, ImageFile, ImageContent, ImageName, SEQ_NUM from eimages join EditedImages on eimages.imageid = editedimages.imageid where QuestionID = @QuestionID", Conn);
        ed.SelectCommand.Parameters.Add("QuestionID", SqlDbType.BigInt).Value = Convert.ToInt32(Request["Id"]);
        ed.Fill(edt);
    }
    dlImages.DataSource = dt;
    dlImages.DataBind();
    EditImages.DataSource = edt;
    EditImages.DataBind();
