    public class WorkflowStateSetRepository : IWorkflowStateSetRepository{
	    
        public IQueryable<Model.WorkflowState> GetAllWorkflows(int state){
		    return DbSet.WorkflowState .Where(w => w.stateId == state);
    	}
    }
