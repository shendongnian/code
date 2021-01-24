    public class SystemThrottledTriggerListener : ITriggerListener
    {
        public string Name => "System Throttled Trigger Listener";
        public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {
            // no need for implementation
        }
        public void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {
            // no need for implementation
        }
        public void TriggerMisfired(ITrigger trigger)
        {
            // no need for implementation
        }
        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            // If you return true, then the Trigger is vetoed and the job is not executed.
            // The Job will automatically scheduled for his next execution
            return IsSystemThrottled();
        }
    }
