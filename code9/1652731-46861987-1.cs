        public static IEnumerable<AmountRange> GetAmountRange(int[] terms)
        {
            return amountTable
                .Join(terms, 
                    range => range.Term, 
                    term => term, 
                    (range, term) => new { range, term })
               .Where(x => x.term.IsBetween(x.range.MinTerm, x.range.MaxTerm))
               .Select(x => new AmountRange(x.term, x.range.MinTerm, x.range.MaxTerm));
        }
