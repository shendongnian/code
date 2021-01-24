    public JsonResult GetDPS(string sidx, string sord, int page, int rows, string startdate, string enddate, string EmployeeId, string month, string year, int ClassificationId)
        {
            var context = new Entities();
            var _pr = new Repository();
            int _month = Convert.ToInt32(month);
            int _employeeid = Convert.ToInt32(EmployeeId);
            int _year = Convert.ToInt32(year);
            if (_month > 0 && _year > 0)
            {
                DateTime Dstartdate = new DateTime(_year, _month, 1);
                startdate = Dstartdate.AddDays(-1).ToShortDateString();
                enddate = Dstartdate.AddMonths(1).ToShortDateString();
            }
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var periods = _pr.GetDPSList(Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), _employeeid, ClassificationId);
            int totalRecords = periods.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
            var reqs = periods.OrderBy(x=>x.DateApplied).Skip(pageIndex * pageSize).Take(pageSize);
            int i = 0;
            var rowsObj = new object[pageSize > totalRecords ? totalRecords : pageSize];
            foreach (vwDPSPerEmployee req in reqs)
            {
                int rowId = i;
                int DPSHeaderId = Convert.ToInt32(req.DPSHeaderId);
                string DateApplied = req.DateApplied.Value.ToShortDateString();
                string DPSClassification = req.DPSClassificationDesc;
                string StartDate = req.DateFrom.Value.ToShortDateString();
                string EndDate = req.DateTo.Value.ToShortDateString();
                string Departure = req.Departure.Value.ToShortTimeString();
                string Arrival = req.Arrival.Value.ToShortTimeString();
                string Destination = req.Destination;
                string ContactPerson = req.ContactPerson;
                string Purpose = req.Purpose;
                rowsObj[i] = new { id = i, cell = new object[] { rowId, DPSHeaderId, DateApplied, DPSClassification, StartDate, EndDate, DateofDPS, Departure, Arrival, Destination, ContactPerson, Purpose } };
                i++;
            }
            if (totalRecords != 0)
            {
                for (int j = 0; j < rowsObj.Length; j++)
                {
                    if (rowsObj[j] == null)
                    { rowsObj[j] = new { id = j, cell = new object[] { j, j, "", "" } }; }
                    else { }
                }
            }
            var result = new JsonResult();
            result.Data = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = rowsObj
            };
            return result;
        }
