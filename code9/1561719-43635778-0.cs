    string path = Server.MapPath(@"../CustomReports/CustomeReports.dll");
            
            if (FileOrDirectoryExists(path))
            {
                var className = "CustomReports";
                var ProductVersion = FileVersionInfo.GetVersionInfo(path).ProductVersion;
                var assemblyName = "CustomeReports, Version=" + ProductVersion.ToStringIC() + ", Culture=neutral, PublicKeyToken=null";
                assembly = Assembly.LoadFrom(path);
               // ViewState["AssemblyInfo"] = assembly;
                hdnDLLValue.Value = "1";
                string strReportName = "Custom Reports";
                object result = null;
                result = returnDLLObject("GetReportNameList");
                int a = SpectraBL.Application.AccessControl.ToInt32IC();
                if (result != null)
                {
                    if (result is IEnumerable)
                    {
                        List<object> list = new List<object>();
                        var enumerator = ((IEnumerable)result).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            list.Add(enumerator.Current);
                        }
                        List<dynamic> dynamicList = list.Select(x => (dynamic)x).ToList();
                        if (dynamicList.Count != 0)
                        {
                            Childnode = new TreeNode("<span id='reportgrp' class='reportmenu label' onclick= OnNodeClick('G','" + strReportName + "','1'); > " + strReportName + " </span>", "Dynamic Reports");
                            Childnode.SelectAction = TreeNodeSelectAction.None;
                            TreeView1.Nodes.Add(Childnode);
                            for (var i = 0; i < dynamicList.Count; i++)
                            {
                                string strChildName = dynamicList[i].ReportName;
                                if (dynamicList[i].isDisplay)
                                {
                                    TreeNode Namenode = new TreeNode();
                                    if (ReportID == dynamicList[i].Reportid)
                                    {
                                        //With selection on pageload
                                        Namenode = new TreeNode("<span id='report" + dynamicList[i].ReportName + "' class='reportmenu label selected' onclick= OnNodeClick('C','" + dynamicList[i].Reportid + "','1'); > " + strChildName + " </span>", strChildName);
                                    }
                                    else
                                    {
                                        //Without selection
                                        Namenode = new TreeNode("<span id='report" + dynamicList[i].ReportName + "' class='reportmenu label' onclick= OnNodeClick('C','" + dynamicList[i].Reportid + "','1'); > " + strChildName + " </span>", strChildName);
                                    }
                                    Namenode.SelectAction = TreeNodeSelectAction.None;
                                    Childnode.ChildNodes.Add(Namenode);
                                }
                            }
                        }
                    }
                }
            }
