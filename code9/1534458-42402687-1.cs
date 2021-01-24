    public class OtherFormDialog : IDialog<CustomFormDialog>
    {
        private readonly CustomFormDialog formData;
    
        public OtherFormDialog(CustomFormDialog prevState)
        {
            this.formData = prevState;
        }
    
        public async Task StartAsync(IDialogContext context)
        {
            //Here, we can do anything
            await context.PostAsync("I'll check your data. Please wait!");
    
            await context.PostAsync("Just joking! No validation at all.");
            context.Done(this.formData);
        }
    }
