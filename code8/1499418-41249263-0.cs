    [Serializable]
    public sealed class ErrorMessageDialog<T, E> : IDialog<T> where E : Exception
    {
        public readonly IDialog<T> Antecedent;
        public ErrorMessageDialog(IDialog<T> antecedent)
        {
            SetField.NotNull(out this.Antecedent, nameof(antecedent), antecedent);
        }
        async Task IDialog<T>.StartAsync(IDialogContext context)
        {
            context.Call<T>(this.Antecedent, ResumeAsync);
        }
        private async Task ResumeAsync(IDialogContext context, IAwaitable<T> result)
        {
            try
            {
                context.Done(await result);
            }
            catch (E)
            {
                await context.PostAsync("sorry");
                context.Done(default(T));
            }
        }
