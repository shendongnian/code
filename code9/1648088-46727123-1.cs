    using Microsoft.Bot.Builder.Dialogs;
    using System.Threading.Tasks;
    namespace pc.apm.bot.tests.Interfaces
    {
        public  interface IMessageRecievedDialog<T> : IDialog<T>
        {
            Task MessageRecievedAsync(IDialogContext context, IAwaitable<T> result);
        }
    }
