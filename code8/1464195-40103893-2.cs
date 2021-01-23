    public async Task DoesCustomerHaveBillAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            IMessageActivity message = await argument;
            switch (message.Text.ToLower())
            {
                case "yes":
                    await context.PostAsync($"Great. Go ahead and take a picture of the first couple of pages and attach them to this conversation.\n\n\nWhen you have finished, please send the message 'finished'.");
                    context.Wait(CustomerHasBillAsync);
                    break;
                case "no":
                    await context.PostAsync($"That's OK. Do you happen to have the login information for your provider account?");
                    context.Wait(CustomerDoesntHaveBillAsync);
                    break;
                default:
                    await context.PostAsync($"Sorry, I didn't undestand. Please reply with 'yes' or 'no'.");
                    context.Wait(DoesCustomerHaveBillAsync);
                    break;
            }
        }
