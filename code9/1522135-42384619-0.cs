    //XML save throught dataset
        private void XMLsave(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "OrderData";
            dt.Columns.Add("OrderNr");
            dt.Columns.Add("Custommer");
            dt.Columns.Add("Material");
            dt.Columns.Add("MaterialCode");
            ds.Tables.Add(dt);
            DataTable dt1 = new DataTable();
            dt1.TableName = "Data";
            dt1.Columns.Add("Lenght");
            dt1.Columns.Add("Width");
            dt1.Columns.Add("Qty");
            ds.Tables.Add(dt1);
            DataRow row = ds.Tables["OrderData"].NewRow();
            row["OrderNr"] = tbOrderNr.Text;
            row["Custommer"] = tbCustommer.Text;
            row["Material"] = tbMaterial.Text;
            row["MaterialCode"] = tbForm2MatCode.Text;
            ds.Tables["Data"].Rows.Add(row);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["Data"].NewRow();
                row1["Lenght"] = r.Cells[0].Value;
                row1["Width"] = r.Cells[1].Value;
                row1["Qty"] = r.Cells[2].Value;
                ds.Tables["Data"].Rows.Add(row1);
            }
            ds.WriteXml("test.xml");
            dataGridView1.AllowUserToAddRows = true;
        }
