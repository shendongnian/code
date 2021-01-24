    ICollection<AttendanceLog> lstMachineInfo = manipulator.GetLogData(objZkeeper2, machineNum);
            if (lstMachineInfo != null && lstMachineInfo.Count > 0)
            {
                var lastRecord = db.yourTableNameHere.OrderByDescending(x => x.DateTime).FirstOrDefault();
                if (lastRecord != null)
                {
                    lstMachineInfo = lstMachineInfo.Where(x => x.DateTime > lastRecord.DateTime).ToList();
                }
                foreach (var p in lstMachineInfo)
                {
                    db.yourTableNameHere.Add(p);
                }
                db.SaveChanges();
