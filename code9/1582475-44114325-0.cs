            DataTable foo = getSudentRecord();
            string serializedFormat = "{{{0}}},{{{1}}},{{{2}}}";
            List<string> subjectnames = new List<string>();
            List<string> units = new List<string>();
            List<string> scores = new List<string>();
            foreach (DataRow row in foo.Rows)
            {
                subjectnames.Add(row["SubjectName"].ToString());
                units.Add(row["Unit"].ToString());
                scores.Add(row["Score"].ToString());
            }
            string serialized = String.Format(serializedFormat,
                String.Join(",",subjectnames.ToArray()),
                String.Join(",", units.ToArray()),
                String.Join(",", scores.ToArray())
                );
            //finally fill the repeater
            repeater.DataSource = foo;
            repeater.DataBind();
