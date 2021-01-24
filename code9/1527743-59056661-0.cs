public void ConfigureServices(IServiceCollection services)
{
    services.AddLocalization();
}
in your bot class:
protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
{
	BotResource.CultureInfo = new CultureInfo("en-GB"); 
	//OR 
	BotResource.CultureInfo = new CultureInfo(turnContext.Activity.Locale); 
}
