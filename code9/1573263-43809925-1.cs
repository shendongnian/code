        void ReplaceTemplateBlockAction(Tuple<string, IDictionary<string, string>> tuple)
        {
            var (template, replacers) = tuple;
            …
        }
        …
        var getReplacersBlock = new WriteOnceBlock<IDictionary<string, string>>(null);
        var replaceTemplateBlock = new ActionBlock<Tuple<string, IDictionary<string, string>>>(
            ReplaceTemplateBlockAction);
        …
        getReplacersBlock.Post(replacers);
