    [Serializable]
    public class CustomFormDialog
    {
        public DateTime Time { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public static IForm<CustomFormDialog> Build()
        {
            OnCompletionAsyncDelegate<CustomFormDialog> processOrder = async (context, state) =>
            {
                await context.Forward(new OtherFormDialog(state), onOtherFormProcessed, state, CancellationToken.None);
            };
            return new FormBuilder<CustomFormDialog>()
                .Field(nameof(Time))
                .Field(nameof(Number1))
                .Field(nameof(Number2))
                .AddRemainingFields()
                .Confirm("Would you like to process?")
                .OnCompletion(processOrder)
                .Build();
        }
        private static async Task onOtherFormProcessed(IDialogContext context, IAwaitable<CustomFormDialog> result)
        {
            var formValue = await result;
            await context.PostAsync($"You are again in the form: Time: {formValue.Time}, Number1: {formValue.Number1}, Number2: {formValue.Number2}");
        }
    }
