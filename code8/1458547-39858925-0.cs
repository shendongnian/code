     public class CustomWorkflowEventsAttribute : CMSLoaderAttribute
    {
        public override void Init()
        {
            WorkflowEvents.Publish.Before += PublishDocument;
        }
