    [WorkflowDescription("1.0")]
    public class OrderWorkflow : Workflow
    {
        public OrderWorkflow()
        {
            ScheduleActivity<ReserveOrder>().OnFailure(PauseWhenItemIsNotAvailable);
            ScheduleActivity<ChargeCustomer>().AfterActivity<ReserveOrder>();
            ScheduleActivity<ShipOrder>().AfterActivity<ChargeCustomer>();
        }
        private WorkflowAction PauseWhenItemIsNotAvailable(ActivityFailedEvent e)
        {
            return e.Reason == "NotAvailable" ? Ignore : DefaultAction(e);
        }
        [WorkflowEvent(EventName.Signal)]
        public WorkflowAction SignalEvent(WorkflowSignaledEvent @event)
        {
            if (@event.SignalName == "ItemsArrived" && Activity<ReserveOrder>().LastFailedEvent()?.Reason=="NotAvailable")
                return Jump.ToActivity<ReserveOrder>();
            return Ignore;
        }
    }
