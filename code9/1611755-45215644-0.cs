            foreach (DataRow dtRow in dt.Rows)
            {
                //I Need to Add here tblSEQOfEvents.AddRow
                List<IContentItem> items = new List<IContentItem>();
                foreach (DataColumn dc in dt.Columns)
                {
                    items.Add(new FieldContent(dc.ColumnName, dtRow[dc].ToString()));
                }
                tblSEQOfEvents.AddRow(items.ToArray());
            }
