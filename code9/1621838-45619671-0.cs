    SELECT product_id, AVG(sale_price)
    FROM Sales
    WHERE sale_date > @0
        AND ([sales].system_id = 450)
    GROUP BY product_id
    Having AVG(sale_price) > @1
    public List<string> GetVariables(string sql)
        {
            List<string> parseErrors;
            List<TSqlParserToken> queryTokens = TokenizeSql(sql, out parseErrors);
            List<string> parameters = new List<string>();
            parameters.AddRange(queryTokens.Where(token => token.TokenType == TSqlTokenType.Variable)
                                            .Select(token => token.Text)
                                            .ToList());
            return parameters;
        }
        private List<TSqlParserToken> TokenizeSql(string sql, out List<string> parserErrors)
        {
            using (System.IO.TextReader tReader = new System.IO.StringReader(sql))
            {
                var parser = new TSql120Parser(true);
                IList<ParseError> errors;
                var queryTokens = parser.GetTokenStream(tReader, out errors);
                if (errors.Any())
                {
                    parserErrors = errors.Select(e => $"Error: {e.Number}; Line: {e.Line}; Column: {e.Column}; Offset: {e.Offset};  Message: {e.Message};").ToList();
                }
                else
                {
                    parserErrors = null;
                }
                return queryTokens.ToList();
            }
        }
