    string uname = "...";
    string pwd = "...";
    param.Add(new SqlParameter("@name", uname));
    param.Add(new SqlParameter("@pwd", pwd));
    Save1(param);
