    public class LeadMaintPXExt : PXGraphExtension<LeadMaint>
    {
        public PXAction<Contact> FollowUpTask;
        [PXUIField(DisplayName = "FollowUp Task")]
        [PXButton()]
        private void followUpTask()
        {
            CRTaskMaint graph = PXGraph.CreateInstance<CRTaskMaint>();
            CRActivity myTask = new CRActivity();
            myTask.Subject = String.Format("FollowUp Lead Test");
            myTask.ClassID = 0;
            DateTime dueDate = DateTime.Now;
            myTask.StartDate = dueDate;
            myTask.EndDate = dueDate.AddDays(10);
            myTask.RefNoteID = Base.Lead.Current.NoteID;
            myTask.ContactID = Base.Lead.Current.ContactID;
            CRActivity task = (CRActivity)graph.Tasks.Insert(myTask);
            graph.Actions.PressSave();
        }
    }
