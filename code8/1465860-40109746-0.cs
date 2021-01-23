        public bool AddAttendace(V_HR_EmployeePlacementDetailed emp, DateTime dt)
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
           
            var empPos = _position.Get(emp.department_id, emp.position_id);
            System.Diagnostics.Debug.WriteLine("a {0}", stopWatch.ElapsedTicks);
            var empPosRoster = _rosterPosition.Get(emp.department_id, emp.position_id, dt);
            System.Diagnostics.Debug.WriteLine("b {0}", stopWatch.ElapsedTicks);
            var empPosLateArrival = empPos.late_arrival;
            var empPosEarlyDeparture = empPos.early_departure;
            System.Diagnostics.Debug.WriteLine("c {0}", stopWatch.ElapsedTicks);
            if (empPosRoster != null)
            {                
                empPosLateArrival = empPosRoster.late_arrival.HasValue ? empPosRoster.late_arrival.Value : empPosLateArrival;
                empPosEarlyDeparture = empPosRoster.early_departure.HasValue ? empPosRoster.early_departure.Value : empPosEarlyDeparture;
                System.Diagnostics.Debug.WriteLine("d {0}", stopWatch.ElapsedTicks);
            }
            var empLeaves = _lapp.GetAll(null, null, dt, dt, null, true, null, null, null, null);
            System.Diagnostics.Debug.WriteLine("e {0}", stopWatch.ElapsedTicks);
            var att = GetAll(dt, new List<long> { emp.employee_id });
            System.Diagnostics.Debug.WriteLine("f {0}", stopWatch.ElapsedTicks);
            var obj = att.Count() > 0 ? att.First() : Get();
            System.Diagnostics.Debug.WriteLine("g {0}", stopWatch.ElapsedTicks);
            var inRecords = _inOut.GetAll(obj.employee_attendance_id, true, null);
            System.Diagnostics.Debug.WriteLine("h {0}", stopWatch.ElapsedTicks);
            var outRecords = _inOut.GetAll(obj.employee_attendance_id, null, true);
            System.Diagnostics.Debug.WriteLine("i {0}", stopWatch.ElapsedTicks);
            obj.employee_id = emp.employee_id;
            obj.date = dt;
            obj.arrival_time = inRecords.Count() == 0 ? dt.TimeOfDay : obj.arrival_time;
            obj.departure_time = inRecords.Count() > 0 ? dt.TimeOfDay : obj.departure_time;
            System.Diagnostics.Debug.WriteLine("j {0}", stopWatch.ElapsedTicks);
            dt.TimeOfDay - inRecords.First().@in.Value : obj.total_hours_worked;
            System.Diagnostics.Debug.WriteLine("k {0}", stopWatch.ElapsedTicks);
            if (obj.arrival_time.HasValue && empPosLateArrival.HasValue && obj.arrival_time > empPosLateArrival)
            {
                obj.late_arrival = obj.arrival_time - empPosLateArrival;
                System.Diagnostics.Debug.WriteLine("l {0}", stopWatch.ElapsedTicks);
            }
            if (obj.early_departure.HasValue && empPosEarlyDeparture.HasValue && obj.departure_time < empPosEarlyDeparture)
            {
                obj.early_departure = empPosEarlyDeparture - obj.departure_time;
                System.Diagnostics.Debug.WriteLine("m {0}", stopWatch.ElapsedTicks);
            }
            obj.present = true;
            obj.leave = false;
            obj.holiday = false;
            obj.department_id = emp.department_id;
            obj.position_id = emp.position_id;
            System.Diagnostics.Debug.WriteLine("n {0}", stopWatch.ElapsedTicks);
            var lapp = (
              from o in empLeaves
              where o.employee_id == emp.employee_id
              select o).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("o {0}", stopWatch.ElapsedTicks);
            if (lapp != null && obj.present != true)
            {
                obj.leave = true;
                obj.leave_type_id = lapp.LeaveTypeId;
                System.Diagnostics.Debug.WriteLine("p {0}", stopWatch.ElapsedTicks);
            }
            var v = _inOut.Get();
            System.Diagnostics.Debug.WriteLine("q {0}", stopWatch.ElapsedTicks);
            if (att.Count() > 0)
            {
                Update();
                v.attendance_id = obj.employee_attendance_id;
                System.Diagnostics.Debug.WriteLine("r {0}", stopWatch.ElapsedTicks);
            }
            else
            {
                Insert(obj);
                v.attendance_id = GetCurrentIdent();
                System.Diagnostics.Debug.WriteLine("s {0}", stopWatch.ElapsedTicks);
            }
            if (inRecords.Count() == 0)
            {
                v.@in = dt.TimeOfDay;
                v.inout_type_id = 1;
                System.Diagnostics.Debug.WriteLine("t {0}", stopWatch.ElapsedTicks);
            }
            else
            {
                v.@out = dt.TimeOfDay;
                v.inout_type_id = 2;
                System.Diagnostics.Debug.WriteLine("u {0}", stopWatch.ElapsedTicks);
            }
            _inOut.Insert(v);
            System.Diagnostics.Debug.WriteLine("v {0}", stopWatch.ElapsedTicks);
            return false;
        }
