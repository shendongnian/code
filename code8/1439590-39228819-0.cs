     public void Carrega_valores()
            {
                GridViewRow[] valoresNovos = new GridViewRow[300];
                valoresNovos = (GridViewRow[])Session["vlColunas"];
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NUMNOTAFISCAL"));
                dt.Columns.Add(new DataColumn("DTEMISSAO"));
                 dt.Columns.Add(new DataColumn("DTVENCIMENTO"));
                 dt.Columns.Add(new DataColumn("DIASANTEC"));
                dt.Columns.Add(new DataColumn("VALTOTAL"));
                 dt.Columns.Add(new DataColumn("VLENCARGOS"));
                dt.Columns.Add(new DataColumn("VLFINAL"));
                foreach (GridViewRow grdCount in valoresNovos)
                {
                    //dt = (DataTable)Session["vlColunas"];
                    if (grdCount != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = grdCount.Cells[1].Text;
                        dr[1] = grdCount.Cells[2].Text;
                        dr[2] = grdCount.Cells[3].Text;
                        dr[3] = grdCount.Cells[7].Text;
                        dr[4] = grdCount.Cells[5].Text;
                        dr[5] = grdCount.Cells[8].Text;
                        dr[6] = grdCount.Cells[5].Text;
                       //dr 7 é valor de 5 menos 8
                        dt.Rows.Add(dr);
                    }
                }
                grdSimulacao.DataSource = dt;
                grdSimulacao.DataBind();
            }
