    public sealed class WebSaveActivity : NativeActivity
    {
        public InArgument<MyBigObject> ObjectToSave { get; set; }
        protected override bool CanInduceIdle
        {
            get
            {
                // This notifies the WF engine that the activity can be unloaded / persisted to an instance store.
                return true;
            }
        }
        protected override void Execute(NativeActivityContext context)
        {
            var currentBigObject = this.ObjectToSave.Get(context);
            currentBigObject.WorkflowInstanceId = context.WorkflowInstanceId;
            StartSaveOperationAsync(this.ObjectToSave.Get(context)); // This method should offload the actual save process to a thread or even a web method, then return immediately.
            
            // This tells the WF engine that the workflow instance can be suspended and persisted to the instance store.
            context.CreateBookmark("MySaveOperation");
        }
    }
