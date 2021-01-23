     [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelFile)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
          Domain.User meu = serv.GetUserByLogin(User.Identity.Name);
            ViewBag.roleid = meu.RoleId;
            NormesSkills ns = serv.GetNormes();
            if (meu.RoleId == 1)
            {
                ViewBag.startBegin = ns.beginnerStart;
                ViewBag.endbegin = ns.beginnerEnd;
                ViewBag.startinter = ns.IntermedStart;
                ViewBag.endinter = ns.IntermedEnd;
                ViewBag.startadv = ns.AdvStart;
                ViewBag.endadv = ns.AdvEnd;
            }
            List<Domaine> domaines = new List<Domaine>();
            List<User> users = new List<Domain.User>();
            if (meu.RoleId == 1)
            {
                domaines = serv.getAlldomains();
                users = serv.GetAllUsers().ToList();
                users.Remove(meu);
            }
            else
            {
                domaines = meu.team.Domaines.ToList();
                if (meu.RoleId == 2)
                {
                    Team t = serv.GetTeamByUserName(meu.UserName);
                    domaines.AddRange(t.Domaines.ToList());
                    users = t.Users.ToList();
                    users.Add(meu);
                }
                if (meu.RoleId == 3)
                    users.Add(meu);
            }
            List<string> d = domaines.Select(x => x.DomainName).Distinct().ToList();
            int l = users.Count + 1;
            int c = d.Count + 1;
            string[,] matrix = new string[l, c];
            string[,] matrixUpdate = new string[l, c];
            int k = 1;
            foreach (var dd in d)
            {
                matrix[0, k] = dd;
                k++;
            }
            int j = 0;
            for (int i = 1; i < l; i++)
            {
                User u = users[i - 1];
                serv.setSkills(u);
                //foreach(var u in users)
                //{
                matrix[i, 0] = u.FirstName + " " + u.LastName;
                for (int y = 1; y < c; y++)
                {
                    bool verifSkillUsr = serv.VerifSkillUsr(d[y - 1], u);
                    if (verifSkillUsr == true)
                    {
                        Skill sk = serv.getSkillUser(d[y - 1], u);
                        if (sk.Evaluation == "0000") sk.Evaluation = "";
                        if (sk.Evaluation == "Beg") sk.Evaluation = "B";
                        if (sk.Evaluation == "Int") sk.Evaluation = "I";
                        if (sk.Evaluation == "Adv") sk.Evaluation = "A";
                        matrix[i, y] = sk.Evaluation;
                        matrixUpdate[i, y] = sk.update.ToString();
                    }
                    else
                    {
                        matrix[i, y] = "";
                    }
                }
                //}
            }
            TempData["skills"] = matrix;
            TempData["skillsUpdate"] = matrixUpdate;
            
            if ((excelFile == null) || (excelFile.ContentLength == 0))
            {
                ViewBag.error = "No  file";
                return View("Index");
            }
            else
            {
                if ((excelFile.FileName.EndsWith("xls")) || (excelFile.FileName.EndsWith("xlsx")))
                {
                    string path="";
                    DateTime date = DateTime.Now;
                    
                    if  (excelFile.FileName.EndsWith("xls")) 
                    path = Server.MapPath("~/Content/Excel/"+date.ToString().Replace("/","-").Replace(":","-")+".xls");
                       
                    else
                        path = Server.MapPath("~/Content/Excel/" + date.ToString().Replace("/", "-").Replace(":", "-") + ".xlsx");
                    string[] filePaths = Directory.GetFiles(Server.MapPath("~/Content/Excel/"));
                    foreach (string filePath in filePaths)
                    {
                        try
                        {
                             System.IO.File.Delete(filePath);
                        }
                        catch { }
                        
                    }
                        
                    //if (System.IO.File.Exists(path))
                    //    System.IO.File.Delete(path);
                    excelFile.SaveAs(path);
                    // Reading data from excel
                    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(path);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;
                    if (range.Rows.Count < 2)
                    {
                        ViewBag.errorin = "File does not contain users";
                        return View("Index");
                    }
                    if (range.Columns.Count < 2)
                    {
                        ViewBag.errorin = "File does not contain domains";
                        return View("Index");
                    }
                    int cols=range.Columns.Count;
                    int lines=range.Rows.Count;
                    List<string> domains=new List<string>();;
                    
                    for(int i=2;i <=cols;i++)
                    {
                        string dom = ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString() ;
                        if ((dom != "") && (dom != null))
                        {
                            dom = dom.ToLower();
                            domains.Add(dom);
                        }
                    }
                    domains = domains.Distinct().ToList();
                    foreach(string dd in domains)
                    {
                       string  dds = dd.Trim();
                        bool h = serv.verifExistenceDomaine(dds);
                        
                        if(h==false)
                        {
                            if(meu.RoleId==2)
                            {
                                serv.AddDomaine(dds, 0, serv.GetTeamByUserName(meu.UserName).Team_Id);
                            }
                            else
                            {
                            foreach (var t in serv.GetAllTeams())
                            { serv.AddDomaine(dds, 0, t.Team_Id); }
                            }
                        }
                        
                    }
                    
                    for (int row = 2; row <= range.Rows.Count;row++ )
                    {
                        List<string> verifinsertion = new List<string>();
                        //    string dom = ((Microsoft.Office.Interop.Excel.Range)range.Cells[0, i]).Text;
                        string username = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text.ToString();
                        
                        User u = serv.getUserByFLName(username);
                        if(u!=null)
                        {
                            Team t = serv.GetTeamByUserName(meu.UserName);
                            for(int i=2;i<=cols;i++)
                            {
                                bool trouve = false;
                                if (meu.RoleId == 1)
                                {
                                    foreach(var domaineeee in verifinsertion)
                                    {
                                        if (domaineeee == ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString())
                                        {
                                            trouve = true;
                                        }
                                    }
                                    if (trouve == false)
                                    {
                                        serv.updateOrInsertSkill(u, ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString(), ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, i]).Text.ToString());
                                        verifinsertion.Add(((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString());
                                    }
                                }
                                else
                                {
                                     foreach(var domaineeee in verifinsertion)
                                    {
                                        if (domaineeee == ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString())
                                        {
                                            trouve = true;
                                        }
                                    }
                                    if (trouve == false)
                                    {
                                    serv.updateOrInsertSkillTeam(t,u, ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString(), ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, i]).Text.ToString());
                                    verifinsertion.Add(((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString());
                                    }
                                }
                            }
                        }
                    }
                    return RedirectToAction("Index", "Skills");
                }
                else
                {
                    ViewBag.error = "File type error";
                    return View("Index");
                }
            }
        }
