    public async Task CallWebService(int Month, int Year)
        {
            try
            {
                var response = await GetResponseFromWebService.GetResponse<ServiceClasses.RootObject_AttendanceTable>(ServiceURL.GetAttendanceTableList + "Month=" + Month + "&Year=" + Year + "&EmpCd=" + _empCode);
                if (response.Flag == true)
                {
                    if (ListObjAttendanceTblList == null)
                    {
                        ListObjAttendanceTblList = new List<LstAttendanceDtl>();
                    }
                    for (int i = 0; i < response.lstAttendanceDtl.Count; i++)
                    {
                        var objAttendanceTableList = new LstAttendanceDtl();
                        objAttendanceTableList.AttendanceDt = response.lstAttendanceDtl[i].AttendanceDt;
                        objAttendanceTableList.EarlyDeparture = response.lstAttendanceDtl[i].EarlyDeparture;
                        objAttendanceTableList.InTime = response.lstAttendanceDtl[i].EarlyDeparture;
                        objAttendanceTableList.LateArrival = response.lstAttendanceDtl[i].EarlyDeparture;
                        objAttendanceTableList.OutTime = response.lstAttendanceDtl[i].OutTime;
                        objAttendanceTableList.OverTime = response.lstAttendanceDtl[i].OverTime;
                        objAttendanceTableList.Reason = response.lstAttendanceDtl[i].Reason;
                        objAttendanceTableList.Remark = response.lstAttendanceDtl[i].Remark;
                        objAttendanceTableList.Shift = response.lstAttendanceDtl[i].Shift;
                        objAttendanceTableList.WorkingHrs = response.lstAttendanceDtl[i].WorkingHrs;
                        ListObjAttendanceTblList.Add(objAttendanceTableList);
                    }
                }
                else
                {
                }
                if (flag == 1)
                {
                   await ChangeCalendar(CalandarChanges.All);
                }
                else
                {
                   await ChangeCalendar(CalandarChanges.StartDate);
                }
            }
            catch (WebException e)
            {
            }
        } 
