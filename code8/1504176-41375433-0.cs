            IList<IList<Object>> list = new List<IList<Object>>() { };
            for (var i = 0; i < dgvAttendance.Rows.Count - 1; i++)
            {
                List<object> lists = new List<object>() { dgvAttendance.Rows[i].Cells[0].Value.ToString(), 
                    dgvAttendance.Rows[i].Cells[1].Value.ToString(), dgvAttendance.Rows[i].Cells[2].Value.ToString(), 
                    dgvAttendance.Rows[i].Cells[3].Value.ToString() };
                list.Add(lists);
            }
            ValueRange VRange = new ValueRange();
            VRange.Range = range;
            VRange.Values = list;
