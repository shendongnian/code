    // Make returnvalue list of timespans
    private List<TimeSpan> GetSpan()
        {
            List<TimeSpan> allSpans = new List<TimeSpan>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                TimeSpan span = (DateTime.Now - Convert.ToDateTime(row.Cells[2].Value));
                String.Format("{0} hours, {1} minutes, {2} seconds",
                    span.Hours, span.Minutes, span.Seconds);
                // Add timespans to list
                allSpans.Add(span);
            }
            
            // return list
            return allSpans;
        }
