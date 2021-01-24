        private void mainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ConfigsHTM["exechour"] != null)
                {
                    if (DateTime.Now.ToString("HH:mm:ss") == ConfigsHTM["exechour"].ToString())
                    {
                        ClassProcessing clsProc = new ClassProcessing();
                        clsProc.StartDate = DateTime.Now.AddDays(-1);
                        clsProc.EndDate = DateTime.Now.AddDays(-1);
                        clsProc.ProcessAll();
                        if (StatusHTM.Count > 0)
                            StatusHTM.Clear();
                        StatusHTM.Add("locationstatus","Todas as Unidades");
                        StatusHTM.Add("typestatus","Agendado");
                        StatusHTM.Add("exechourstatus", DateTime.Now.ToString("F"));
                        
                        if (clsProc.ReprocessingDone)
                            StatusHTM.Add("statusstatus","OK");
                        else
                            StatusHTM.Add("statusstatus", "Falhou");
                        ClassStatus clsStt = new ClassStatus();
                        clsStt.StatusHT = StatusHTM;
                        clsStt.SaveStatus();
                        GetStatus();
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLog clsLog = new ClassLog();
                clsLog.EventData = "Falha ao Iniciar a Execução do  Aplicativo";
                clsLog.ErrorLog();
                clsLog.EventData = ex.ToString();
                clsLog.ErrorLog();
            }
        }
