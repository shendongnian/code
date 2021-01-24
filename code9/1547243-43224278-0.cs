    public async Task StartAsync(IDialogContext context)
        {
            await this.ShowOptions(context);
        }
        private async Task ShowOptions(IDialogContext context)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, 
                         new List() { ImageOption, ToolOption }, 
                         "Please select one of the following category.", 
                         "Not a valid option", 3);
        }
        private async Task OnOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            string optionSelected = await result;
            switch (optionSelected)
            {
                case ImageOption:
                    context.Call(new ImgRelated(), this.ResumeAfterOptionDialog);
                    break;
                case ToolOption:
                    context.Call(new ToolPBmDailog(), this.ResumeAfterOptionDialog);
                    break;
            }
        }
