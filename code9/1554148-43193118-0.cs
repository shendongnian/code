    private bool TryParseHelpVerb(string[] args, object options, Pair<MethodInfo, HelpVerbOptionAttribute> helpInfo, OptionMap optionMap)
        {
            var helpWriter = _settings.HelpWriter;
            if (helpInfo != null && helpWriter != null)
            {
                if (string.Compare(args[0], helpInfo.Right.LongName, GetStringComparison(_settings)) == 0)
                {
                    // User explicitly requested help
                    // +++ FIX
                    // var verb = args.FirstOrDefault(); // This looks wrong as the first element is always the help command itself
                    var verb = args.Length == 1 ? null : args[1]; // Skip the help command and use next argument as verb
                    // --- FIX
                    if (verb != null)
                    {
                        var verbOption = optionMap[verb];
                        if (verbOption != null)
                        {
                            if (verbOption.GetValue(options) == null)
                            {
                                // We need to create an instance also to render help
                                verbOption.CreateInstance(options);
                            }
                        }
                    }
                    DisplayHelpVerbText(options, helpInfo, verb);
                    return true;
                }
            }
            return false;
        }
