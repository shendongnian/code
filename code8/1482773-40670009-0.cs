     public int PushEventInfo([FromBody]PushEvent push)
        {
            bool flag = true;
            ProjectController project = new ProjectController();
            List<string> projectName = new List<string>();
            try
            {
                SqlConnection conn = connectLocaldb.ConnectDataBase();
                conn.Open();
                string sql = "INSERT INTO MemberCommitBeforeCompiling(Username,ProjectName,Version,GroupName,CommitTime,Branch) VALUES ('" + push.user_name + "','" + push.project.name + "','" + push.after + "','" + groupname + "',getdate(),'" + push.@ref + "') ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                //判断项目是否已存在
                IList<Project> namelist = project.GetAllProjectInfo();
                foreach(var i in namelist)
                {
                   //如果MemberProject表中已经存在该项目
                    if (i.projectName.Contains(push.project.name)|| push.project.name.Contains(i.projectName))
                        flag = false;
                }
                if (flag==true)
                {
                    sql = "INSERT INTO MemberProject(ProjectName,CommitTime,isdelete) VALUES ('" + push.project.name + "',getdate(),'0') ";
                    cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                }
                conn.Close();
                return result;
            }
            catch (Exception e)
            {
                FileStream fs = new FileStream("c:\\test\\log.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs); // 创建写入流
                sw.WriteLine(e.ToString()); // 写入
                sw.Close();
                return 0;
            }
