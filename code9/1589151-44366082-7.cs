    [Serializable]
    public class CurrentDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var promptOptions = new CancelablePromptOptions<string>(MyDictionary.ChooseOneOfTheFollowingOptions, cancelPrompt: "cancel", options: MyHelper.GetOptions(), promptStyler: PromptStyler);
            CancelablePromptChoice<string>.Choice(context, OptionSelected, promptOptions);
        }
		private async Task OptionSelected(IDialogContext context, IAwaitable<string> result)
		{
			var chose = await result;
			string answer = chose.ToString();
			switch (answer)
			{
				case HelpEnumerator.Agenda:
					await EventHelper.GetEventAgenda(context);
					context.Done<string>(null);
					break;
				case HelpEnumerator.Register:
					context.Call(new RegistrationDialog(), RegistrationDialog.Resume);
					context.Done<string>(null);
					break;
				case HelpEnumerator.Speakers:
					await EventHelper.GetSpeakers(context);
					context.Done<string>(null);
					break;
				case HelpEnumerator.Tickets:
					await EventHelper.GetTickets(context);
					context.Done<string>(null);
					break;
				default:
					context.Done(answer);
					break;	
			}
		}
    }
