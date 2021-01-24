cs
// Get skill LUIS model from configuration.
localizedServices.LuisServices.TryGetValue("MySkill", out var luisService);
if (luisService != null)
{
	// Get the Luis result. 
	var result = innerDc.Context.TurnState.Get<MySkillLuis>(StateProperties.SkillLuisResult);
	var intent = result?.TopIntent().intent;
	// Behavior switched on intent. 
	switch (intent)
	{
		case MySkillLuis.Intent.MyIntent:
			{
				// result is passed on to my dialog through the Options parameter. 
				await innerDc.BeginDialogAsync(_myDialog.Id, result);
				break;
			}
		case MySkillLuis.Intent.None:
		default:
			{
				// intent was identified but not yet implemented
				await innerDc.Context.SendActivityAsync(_templateEngine.GenerateActivityForLocale("UnsupportedMessage"));
				break;
			}
	}
}
From our second dialog, we can access the object through the context and perform any casting, etc. as necessary. In my case, it was a waterfall dialog, so I used `stepContext.options`. 
