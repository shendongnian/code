    if (ddBusinessCategory.SelectedValue == "0")
                        {
                            var clients = db.Client_Master.Where(c => c.InquiredFor == PID).ToList();
                            int GrpID = 0;
                            if (clients.Count() > 0)
                            {
                                foreach (var clt in clients)
                                {
                                    if (ProductGrp(PID, clt.CID))
                                    {
                                        Group_Master gobj = new Group_Master();
                                        gobj.GrpID = 0;
                                        gobj.GName = txtGroupName.Text;
                                        gobj.ProductID = PID;
                                        gobj.CatID = null;
                                        gobj.SubCatID = null;
                                        gobj.ClientID = clt.CID;
                                        gobj.CreatedBy = Convert.ToInt32(((User_Master)Session["User"]).UID);
                                        gobj.CreatedOn = DateTime.Now;
                                        db.Group_Master.AddObject(gobj);
                                        db.SaveChanges();
                                        GrpID = gobj.GID;
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "myscript()", "bootbox.alert({title: '<b>Error</b>',message: '<b>Group already exist.</b>',});", true);
                                        break;
                                    }
                                }
                                List<Group_Master> ggobj = db.Group_Master.Where(g => g.ProductID == PID && g.CatID == null && g.SubCatID == null).ToList();
                                foreach (var gid in ggobj)
                                {
                                    if (gid.GrpID == 0)
                                    {
                                        Group_Master gmobj = db.Group_Master.Single(s => s.GID == gid.GID);
                                        gmobj.GrpID = GrpID;
                                        db.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, this.GetType(), "myscript()", "bootbox.alert({title: '<b>Error</b>',message: '<b>No Clients exist.</b>',});", true);
                            }
                        }
 
