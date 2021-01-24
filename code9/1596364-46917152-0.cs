    internal class InvoiceGenerationActor : Actor, IInvoiceGenerationActor, IRemindable
    {
        protected override async Task OnActivateAsync()
        {
            ////ActorEventSource.Current.ActorMessage(this, "Actor activated.");
            //// The StateManager is this actor's private state store.
            //// Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            //// Any serializable object can be saved in the StateManager.
            //// For more information, see https://aka.ms/servicefabricactorsstateserialization
            //// return this.StateManager.TryAddStateAsync("count", 0);
            ////var schedulerDtos = GetSchedulerList();
            await base.OnActivateAsync();
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");
            IActorReminder generationReminderRegistration = await this.RegisterReminderAsync(GenerationRemainder, BitConverter.GetBytes(100), TimeSpan.FromMilliseconds(0), TimeSpan.FromMinutes(10));
            ////IActorReminder mailReminderRegistration = await this.RegisterReminderAsync(generationRemainder, BitConverter.GetBytes(100), TimeSpan.FromMinutes(1), TimeSpan.FromHours(1));
            return;
        }
        public async Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            if (reminderName.Equals(GenerationRemainder))
            {
                await GetAllInvoiceSettingAndRegisterNewRemiders();
            }
            else
            {
                int solutionPartnerId = BitConverter.ToInt32(context, 0);
                var data = await Get("SolutionOwnerInvoiceGeneration/AutomaticInvoiceGeneration/" + solutionPartnerId, "PartnerService");
                await UnregisterReminderAsync(GetReminder(reminderName));
            }
        }
    }
