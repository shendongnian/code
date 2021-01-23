                //Setup list object
                var llist = new List<MyClass>();
                //Loop through datagridview rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // ------------------ changed code ----------------------
                    string datNum = null;     // by-default we say it will be null
                    string nachricht = null;  // same with other field
                    // now we will check if cell does NOT have a  null value
                    if (row.Cells["Datum"].Value != null)
                        // then we will put it in a variable
                        datNum = row.Cells["Datum"].Value.ToString();
                    // similarly for other variable as well
                    if (row.Cells["Nachricht"].Value != null)
                        nachricht = row.Cells["Nachricht"].Value.ToString();
                    var obj = new MyClass()
                    {
                        Datum = datNum,
                        Nachricht = nachricht
                    };
                    // ------------------------------------------------------
                    llist.Add(obj);
                }
