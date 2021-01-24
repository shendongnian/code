    public ActionResult Exercise()
            {
                var dt = new DbAccess();
                var listTree = dt.GetAllTree();
                var list = new List<DTree>();
    
                foreach (var row in listTree)
                {
                    list.Add(
                        new DTree
                        {
                            Id = row.Id,
                            Name = row.Name,
                            ParentId = (Convert.ToInt32(row.ParentId) != 0) ? Convert.ToInt32(row.ParentId) : (int?)null
                        });
                }
    
                TreeViewModel tvm = new TreeViewModel();
                tvm.leafs = list;
                //passed the model 
                return View(tvm );
            }
