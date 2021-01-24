    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using pc.Bot.Form;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace pc.Bot.Dialogs
    {
        [Serializable]
        public class RootDialog : IDialog<object>
        {
            public async Task StartAsync(IDialogContext context)
            {
                context.Wait(MessageReceivedAsync);
                await Task.CompletedTask;
            }
            private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
            {
                var names = new List<string>() { "Pawel", "Tomek", "Marin", "Jakub", "Marco" };
                var form = new FormDialog<MyForm>(new MyForm(names), MyForm.BuildForm, FormOptions.PromptInStart);
                context.Call(form, Form_Callback);
                await Task.CompletedTask;
            }
           private async Task Form_Callback(IDialogContext context, IAwaitable<MyForm> result)
           {
               var formData = await result;
               //output our selected names form our form
               await context.PostAsync("You selected the following names:");
               await context.PostAsync(formData.Names.Aggregate((x, y) => $"{x}, {y}"));
           }
       }
    }
