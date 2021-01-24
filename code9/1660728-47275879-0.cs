    public static IEnumerable<KeyValuePair<string, IntentActivityHandler>> EnumerateHandlers(object dialog)
            {
                var type = dialog.GetType();
                var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var method in methods)
                {
                    var intents = method.GetCustomAttributes<LuisIntentAttribute>(inherit: true).ToArray();
                    IntentActivityHandler intentHandler = null;
    
                    try
                    {
                        intentHandler = (IntentActivityHandler)Delegate.CreateDelegate(typeof(IntentActivityHandler), dialog, method, throwOnBindFailure: false);
                    }
                    catch (ArgumentException)
                    {
                        // "Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type."
                        // https://github.com/Microsoft/BotBuilder/issues/634
                        // https://github.com/Microsoft/BotBuilder/issues/435
                    }
    
                    // fall back for compatibility
                    if (intentHandler == null)
                    {
                        try
                        {
                            var handler = (IntentHandler)Delegate.CreateDelegate(typeof(IntentHandler), dialog, method, throwOnBindFailure: false);
    
                            if (handler != null)
                            {
                                // thunk from new to old delegate type
                                intentHandler = (context, message, result) => handler(context, result);
                            }
                        }
                        catch (ArgumentException)
                        {
                            // "Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type."
                            // https://github.com/Microsoft/BotBuilder/issues/634
                            // https://github.com/Microsoft/BotBuilder/issues/435
                        }
                    }
    
                    if (intentHandler != null)
                    {
                        var intentNames = intents.Select(i => i.IntentName).DefaultIfEmpty(method.Name);
    
                        foreach (var intentName in intentNames)
                        {
                            var key = string.IsNullOrWhiteSpace(intentName) ? string.Empty : intentName;
                            yield return new KeyValuePair<string, IntentActivityHandler>(intentName, intentHandler);
                        }
                    }
                    else
                    {
                        if (intents.Length > 0)
                        {
                            throw new InvalidIntentHandlerException(string.Join(";", intents.Select(i => i.IntentName)), method);
                        }
                    }
                }
            }
