    public class LeadMaintPXExt : PXGraphExtension<LeadMaint>
    {
        public PXAction<Contact> FollowUpTask;
        [PXUIField(DisplayName = "FollowUp Task")]
        [PXButton()]
        private void followUpTask()
        {
            try
            {
                //out-of-box Activities -> "New Task" Action
                Base.Actions["NewTask"].Press();
            }
            catch (Exception ex)
            {
                if (ex is PXRedirectRequiredException)
                {
                    CRTaskMaint graph = (ex as PXRedirectRequiredException).Graph as CRTaskMaint;
                    if (graph != null)
                    {
                        CRActivity myTask = graph.Tasks.Current;
                        myTask.Subject = String.Format("FollowUp Lead Test");
                        myTask.ClassID = 0;
                        DateTime dueDate = DateTime.Now;
                        myTask.StartDate = dueDate;
                        myTask.EndDate = dueDate.AddDays(10);
                        CRActivity task = graph.Tasks.Update(myTask);
                        graph.Actions.PressSave();
                    }
                }
            }
        }
    }
