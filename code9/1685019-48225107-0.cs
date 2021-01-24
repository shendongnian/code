    public ActionResult GetReport(ReportKPIViewModel model)
            {
                clsReportKPI clsReportKPI = new clsReportKPI();
                List<ReportKPIDetailsViewModel> ReportKPIDetails = new List<ReportKPIDetailsViewModel>();
                List<string> CompulsaryFields = new List<string>();
    
                CompulsaryFields.Add("Date");
                CompulsaryFields.Add("AreaName");
                CompulsaryFields.Add("TeamLeaderName");
                CompulsaryFields.Add("QualityAuditorName");
                CompulsaryFields.Add("AgentName");
    
                try
                {
                    var TLGUIDs = clsReportKPI.GetTeamLeaderOpsGUIDs(model.TeamLeadersArray);
                    var QAGUIDs = clsReportKPI.GetQualityAuditorGUIDs(model.QualityAuditorsArray);
                    var AgentGUIDs = clsReportKPI.GetAgentGUIDs(model.AgentsArray);
                    var KPIQAFields = clsReportKPI.GetKPIQAFields(model.KPIArray);
    
                    var qualityAudit = db.QualityAudits.Where(x => (DbFunctions.TruncateTime(x.QualityAuditDate) >= DbFunctions.TruncateTime(model.ReportDateFrom) && DbFunctions.TruncateTime(x.QualityAuditDate) <= DbFunctions.TruncateTime(model.ReportDateTo)) &&  x.AreaId == model.AreaFilterId && TLGUIDs.Contains(x.TeamLeaderOpsId) && QAGUIDs.Contains(x.AuditorId) && AgentGUIDs.Contains(x.AgentId)).ToList();
    
                    foreach (var item in qualityAudit)
                    {
                        item.Date = item.QualityAuditDate;
                        item.AreaName = item.Area.AreaName;
                        item.TeamLeaderName = db.Users.FirstOrDefault(x => x.Id == item.TeamLeaderOpsId).FullName;
                        item.QualityAuditorName = db.Users.FirstOrDefault(x => x.Id == item.AuditorId).FullName;
                        item.AgentName = item.Agent.FirstName.ToString() + " " + item.Agent.LastName.ToString();
                    }
    
                    DataTable dt = LINQToDataTable(qualityAudit, CompulsaryFields, KPIQAFields);
    
                    model.KPIColumnNames = KPIQAFields;
                    model.ReportKPIDetails = ReportKPIDetails;
                    model.dtReportDetails = dt;
    
                    return PartialView("_partialReports", model);
                }
                catch (Exception ex)
                {
                    //model.ReportKPIDetails = ReportDetailsList;
    
                    return PartialView("_partialReports", model);
                }
            }
