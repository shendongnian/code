    public partial class GetGuid : BaseWorkflow
    {
        [Output("Entity Id")]
        public OutArgument<string> EntityId { get; set; }
        protected override void ExecuteInternal(LocalWorkflowContext context)
        {
            EntityId.Set(context.CodeActivityContext, context.WorkflowContext.PrimaryEntityId.ToString());
        }
    }
