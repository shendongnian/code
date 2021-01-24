            var QuoteGroup =
                new QuickFix.FIX44.MassQuote.NoQuoteSetsGroup();
            msg.GetGroup(1, QuoteGroup);
            var QuoteEntry =
                new QuickFix.FIX44.MassQuote.NoQuoteSetsGroup.NoQuoteEntriesGroup();
            QuoteEntry.GetGroup(1, QuoteEntry);
            bidQty = Int32.Parse(QuoteEntry.GetString(134));
