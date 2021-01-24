    public class PromptDialog
    {
        public static void Text(IDialogContext context, ResumeAfter<string> resume, string prompt, string retry = null, int attempts = 3)
        {
            var child = new PromptString(prompt, retry, attempts);
            context.Call<string>(child, resume);
        }
