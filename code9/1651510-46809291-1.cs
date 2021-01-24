    using AIStestv01.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    namespace AIStestv01.Controllers.AdminControllers
    {
        public class EmpController : Controller
        {
            // GET: Emp
            public ActionResult Index()
            {
                var con = ConfigurationManager.ConnectionStrings["WOPcon"].ConnectionString;
                using (SqlConnection conObj = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("wsp_Test01", conObj);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var model = new List<EmpListModel>();
                    conObj.Open();//Openning of the connection associated with the sql command
                    using (SqlDataReader rdr = cmd.ExecuteReader())//Using around the SqlDataReader to dispose it after use
                    {
                        while (rdr.Read())
                        {
                            var emp = new EmpListModel();
                            emp.BioID = Convert.ToString(rdr["BioID"]);
                            emp.Fullname = Convert.ToString(rdr["Fullname"]);
                            emp.Dthired = Convert.ToString(rdr["Dthired"]);
                            emp.DeptID = Convert.ToString(rdr["DeptID"]);
                            emp.Active = Convert.ToString(rdr["Active"]);
                            emp.NTLogin = Convert.ToString(rdr["NTLogin"]);
                            model.Add(emp);
                        }
                    }
                }
                //do something with the 
    
                return View(model);//added model to use it in cshtml
            }
        }
    }
