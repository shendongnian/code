    string participante = (txtParticipante.Value == "" ? " " : txtParticipante.Value);
            dsReportes.SP_REPORTE_EVENTOS_CALENDARIODataTable dt = new dsReportes.SP_REPORTE_EVENTOS_CALENDARIODataTable();
            DataTable table = new DataTable();
            dsReportesTableAdapters.SP_REPORTE_EVENTOS_CALENDARIOTableAdapter da = new dsReportesTableAdapters.SP_REPORTE_EVENTOS_CALENDARIOTableAdapter();
            ReportDataSource RD = new ReportDataSource();
            table = dt.Clone();
            var FechaInicio_ini = FechaInicio(CEV_FECHA_INICIO_ini.Value);
            var FechaInicio_fin = FechaFin(CEV_FECHA_INICIO_fin.Value);
            var FechaFin_ini = FechaInicio(CEV_FECHA_FIN_Ini.Value);
            var FechaFin_fin = FechaFin(CEV_FECHA_FIN_fin.Value);
            
            try
            {
                if (ddUsu.SelectedValue != "")
                {
                    foreach (ListItem item in ddUsu.Items)
                    {
                        if (item.Selected == true)
                        {
                            da.Fill(dt, int.Parse(item.Value),
                                   FechaInicio_ini, FechaInicio_fin,
                                  FechaFin_ini, FechaFin_fin,(txtParticipante.Value == "" ? " " : txtParticipante.Value));
                            foreach (DataRow dr in dt)
                            {
                                table.Rows.Add(dr.ItemArray);
                            }
                        }
                    }
                }
                else
                {
                    foreach(ListItem item in ddUsu.Items)
                    {
                        da.Fill(dt, int.Parse(item.Value == "" ? "0" : item.Value),
                                  FechaInicio_ini, FechaInicio_fin,
                                 FechaFin_ini, FechaFin_fin, (txtParticipante.Value == "" ? " " : txtParticipante.Value));
                        foreach (DataRow dr in dt)
                        {
                            table.Rows.Add(dr.ItemArray);
                        }
                    }
                }
                divReporte.Visible = true;
                RD.Value = table;
                RD.Name = "dbCalendarioEventos";
                rvReporteCalendarioEventos.LocalReport.DataSources.Clear();
                rvReporteCalendarioEventos.LocalReport.DataSources.Add(RD);
                rvReporteCalendarioEventos.LocalReport.ReportEmbeddedResource = "ReporteCalendarioEventos.rdlc";
                rvReporteCalendarioEventos.LocalReport.ReportPath = @"Reportes\Calendario\ReporteCalendarioEventos.rdlc";
                rvReporteCalendarioEventos.LocalReport.Refresh();
            }
            catch(Exception ex) { }            
        }
