            string[][,] PatternTables;
            Parallel.For(0, PatternTables.Length,
                index =>
                {
                    PatternTables[index] = BOMAnalysis(Pattern, PatternMatch, BOMs, HeaderIndex);
                });
