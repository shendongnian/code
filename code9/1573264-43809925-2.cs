        void ReplaceTemplateBlockAction(string template, IDictionary<string, string>>> replacers)
        {
            …
        }
        …
        var getReplacersTcs = new TaskCompletionSource<IDictionary<string, string>>();
        var replaceTemplateBlock = new ActionBlock<string>(
            async template => ReplaceTemplateBlockAction(template, await getReplacersTcs.Task));
        …
        getReplacersTcs.SetResult(replacers);
