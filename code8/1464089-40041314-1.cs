    public string Delete(vw_Host host, string name) {
        ObjectParameter executionStatus = new ObjectParameter("ExecutionStatus", "");
    
        try {
            using (Entities context = new Entities()) {
                context.sp_Host_Delete(host.ID, name, executionStatus);
                context.SaveChanges();
            }
        } catch (Exception ex) {
            using (Entities context = new Entities()) {
                context.sp_LogError(this.GetType().Name.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, name);
                context.SaveChanges();
            }
    
            executionStatus.Value = "Error occured. Please contact to Administrator";
        }
    
        return executionStatus.Value.ToString();
    }
