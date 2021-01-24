    protected virtual async Task DispatchToIntentHandler(IDialogContext context,
                                                                IAwaitable<IMessageActivity> item,
                                                                IntentRecommendation bestIntent,
                                                                LuisResult result)
            {
                if (this.handlerByIntent == null)
                {
                    this.handlerByIntent = new Dictionary<string, IntentActivityHandler>(GetHandlersByIntent());
                }
    
                IntentActivityHandler handler = null;
                if (result == null || !this.handlerByIntent.TryGetValue(bestIntent.Intent, out handler))
                {
                    handler = this.handlerByIntent[string.Empty];
                }
    
                if (handler != null)
                {
                    await handler(context, item, result);
                }
                else
                {
                    var text = $"No default intent handler found.";
                    throw new Exception(text);
                }
            }
