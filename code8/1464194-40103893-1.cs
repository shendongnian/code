    [Serializable]
    public class BillSharkDialog : IDialog<object>
    {
        Model.Customer customer = new Model.Customer();
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(WelcomeMessageAsync);
        }
        public async Task WelcomeMessageAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            IMessageActivity message = await argument;
            await context.PostAsync("We're excited to start helping you save! Let's start by getting your name?");
            context.Wait(CaptureCustomerNameAsync);
        }
        public async Task CaptureCustomerNameAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            IMessageActivity message = await argument;
            customer.customerName = message.Text;
            await context.PostAsync($"Thanks {message.Text}. Now we need your email address?");
            context.Wait(CaptureCustomerEmailAsync);
        }
    }
