    [LuisIntent("SomeIntent")]
        public async Task SomeIntent(IDialogContext context, LuisResult result)
        {
            PromptDialog.Attachment(
                   context: context,
                   resume: ResumeAfterExpenseUpload,
                   prompt: "I see you are trying to add an expense. Please upload a picture of your expense and I will try to perform character recognition (OCR) on it.",
                   retry: "Sorry, I didn't understand that. Please try again."
               );
         }
        private async Task ResumeAfterExpenseUpload(IDialogContext context, IAwaitable<IEnumerable<Attachment>> result)
        {
            var attachment = await result as IEnumerable<Attachment>;
            var attachmentList = attachment.GetEnumerator();
            if (attachmentList.MoveNext())
            {
                //output link to the uploaded file
                await context.PostAsync(attachmentList.Current.ContentUrl); 
            }
            else
            {
                await context.PostAsync("Sorry, no attachments found!");
            }
                     
        }
