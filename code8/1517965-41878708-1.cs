    public void CustomAUM_Update(RiskReportDataViewModel riskReportDataViewModel, string userName)
            {
                    var entity = new CustomAUM();
    
                    entity = riskContext.CustomAUM.FirstOrDefault(x => x.ID == riskReportDataViewModel.ID && x.Client == riskReportDataViewModel.Client && x.Portfolio == riskReportDataViewModel.Portfolio);
    
                    entity.Client = riskReportDataViewModel.Client;
                    entity.Portfolio = riskReportDataViewModel.Portfolio;
                    entity.AUM = riskReportDataViewModel.AUM;
                    entity.EffectiveDate = DateTime.Parse(riskReportDataViewModel.EffectiveDate.ToShortDateString());
                    entity.IsStatic = riskReportDataViewModel.IsStatic;
                    entity.sysDate = DateTime.Now;
                    entity.ModifiedBy = userName;
    
                    riskContext.CustomAUM.Attach(entity);
                    riskContext.Entry(entity).State = EntityState.Modified;
                    riskContext.SaveChanges();
            }
