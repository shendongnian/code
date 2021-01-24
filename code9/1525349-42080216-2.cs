    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable AspNetRoles = new DataTable();
                AspNetRoles.Columns.Add("Id", typeof(int));
                AspNetRoles.Columns.Add("Name", typeof(string));
                AspNetRoles.Rows.Add(new object[] { 123, "Developer" });
                AspNetRoles.Rows.Add(new object[] { 456, "Non Developer" });
                DataTable AspNetUserRoles = new DataTable();
                AspNetUserRoles.Columns.Add("UserId", typeof(int));
                AspNetUserRoles.Columns.Add("RoleId", typeof(int));
                AspNetUserRoles.Rows.Add(new object[] { 100, 123 });
                AspNetUserRoles.Rows.Add(new object[] { 200, 456 });
                AspNetUserRoles.Rows.Add(new object[] { 300, 123 });
                AspNetUserRoles.Rows.Add(new object[] { 400, 456 });
                DataTable AspNetUsers = new DataTable();
                AspNetUsers.Columns.Add("Id", typeof(int));
                AspNetUsers.Rows.Add(new object[] { 100 });
                AspNetUsers.Rows.Add(new object[] { 200 });
                AspNetUsers.Rows.Add(new object[] { 300 });
                AspNetUsers.Rows.Add(new object[] { 400 });
                DataTable UserToTask = new DataTable();
                UserToTask.Columns.Add("UserId", typeof(int));
                UserToTask.Columns.Add("TaskId", typeof(int));
                UserToTask.Rows.Add(new object[] { 100, 1000 });
                UserToTask.Rows.Add(new object[] { 100, 1001 });
                UserToTask.Rows.Add(new object[] { 100, 1002 });
                UserToTask.Rows.Add(new object[] { 200, 1001 });
                UserToTask.Rows.Add(new object[] { 200, 1004 });
                UserToTask.Rows.Add(new object[] { 200, 1006 });
                UserToTask.Rows.Add(new object[] { 300, 1005 });
                UserToTask.Rows.Add(new object[] { 300, 1006 });
                UserToTask.Rows.Add(new object[] { 400, 1007 });
                UserToTask.Rows.Add(new object[] { 400, 1008 });
                DataTable ProjectTasks = new DataTable();
                ProjectTasks.Columns.Add("Id", typeof(int));
                ProjectTasks.Columns.Add("Status", typeof(string));
                ProjectTasks.Rows.Add(new object[] { 1000, "Active" });
                ProjectTasks.Rows.Add(new object[] { 1001, "Testing" });
                ProjectTasks.Rows.Add(new object[] { 1002, "Idle" });
                ProjectTasks.Rows.Add(new object[] { 1003, "Active" });
                ProjectTasks.Rows.Add(new object[] { 1004, "Testing" });
                ProjectTasks.Rows.Add(new object[] { 1005, "Idle" });
                ProjectTasks.Rows.Add(new object[] { 1006, "Active" });
                ProjectTasks.Rows.Add(new object[] { 1007, "Testing" });
                ProjectTasks.Rows.Add(new object[] { 1008, "Idle" });
                var results = (from task in UserToTask.AsEnumerable()
                               join proj in ProjectTasks.AsEnumerable() on task.Field<int>("TaskId") equals proj.Field<int>("Id")
                               join aspNetUser in AspNetUsers.AsEnumerable() on task.Field<int>("UserId") equals aspNetUser.Field<int>("Id")
                               join aspNetUserRole in AspNetUserRoles.AsEnumerable() on aspNetUser.Field<int>("Id") equals aspNetUserRole.Field<int>("UserId")
                               join aspNetRole in AspNetRoles.AsEnumerable() on aspNetUserRole.Field<int>("RoleId") equals aspNetRole.Field<int>("Id")
                               select new { task = task, proj = proj, aspNetUser = aspNetUser, aspNetUserRole = aspNetUserRole, aspNetRole = aspNetRole })
                               .ToList();
                var finalResults = results.GroupBy(x => x.task.Field<int>("UserId"))
                    .Where(x => (x.Select(y => y.task).Count() == 0) || (x.Where(y => (y.proj.Field<string>("Status") == "Active") || (y.proj.Field<string>("Status") == "Testing"))).Count() <= 3).ToList();
            }
        }
    }
