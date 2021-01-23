    private void btnLogin_Click(object sender, EventArgs e)
    // parts of your code till this line :
    SchoolDBEntities db = new SchoolDBEntities();
    var tid = from t in db.Teachers
              where t.TID == Username
              && t.Password == txtPassword.Text
              select t;
    Teacher teacher = tid.FirstOrDefault();
    if(teacher != null)
    {
        SessionManagement.LoggedAs((UserEntity)teacher);
    }
    // do the same with Administrator
