            var qryRoute = (from rm in db.RouteMasters
                            from um in db.UserMasters
                            where um.UserID == uid
                            && rm.UnitID == um.UnitID
                            && rm.ForDept == um.DeptID
                            && rm.RouteType == "General"
                            && rm.IsActive == 1
                            select new
                            {
                                rm.RouteID,
                                rm.UnitID,
                                rm.ForDept,
                                rm.RouteType,
                                rm.ReqDept,
                                rm.ReqDesg,
                                rm.Seq,
                                rm.IsActive
                            });
            obj.RouteList = new List<RouteMaster>();
            foreach (var i in qryRoute)
            {
                obj.RouteList.Add(new RouteMaster
               {
                   RouteID = i.RouteID,
                   UnitID = i.UnitID,
                   ForDept = i.ForDept,
                   RouteType = i.RouteType,
                   ReqDept = i.ReqDept,
                   ReqDesg = i.ReqDesg,
                   ReqDeptName = db.DeptMasters.FirstOrDefault(x => x.DeptID == i.ReqDept).Department,
                   ReqDesgName = db2.DESG_MASTER.FirstOrDefault(x => x.ID == i.ReqDesg).DESG_ID,
                   Seq = i.Seq,
                   IsActive = i.IsActive
               });
            }
