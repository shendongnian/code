            RuleFor(catname => catname.CatName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom((catname, context) =>
                {
                    if (!context.ParentContext.RootContextData.ContainsKey("HasCat"))
                    {
                        // You may not want to flag this, as you'd likely have a separate rule for that on the other property
                        context.AddFailure("You need to indicate whether you have a cat or not...");
                    }
                    else
                    {
                        var hasCat = (bool)context.ParentContext.RootContextData["HasCat"];
                        if (hasCat && string.IsNullOrWhiteSpace(catname))
                        {
                            context.AddFailure("Please provide the name of your cat.");
                        }
                        // other checks, or just chain more below like you usually would since we StopOnFirstFailure
                    }
                });
