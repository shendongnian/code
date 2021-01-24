    private bool TryParseSQLExpr(ref string strSQL, ref List<string> attribs, ExprState state = ExprState.Expression) {
        bool ans = true;
    
        while (strSQL.Length > 0 && ans) {
            strSQL = strSQL.TrimStart();
    
            var skipLen = 0;
            switch (state) {
                case ExprState.Expression:
                    if (strSQL.StartsWith("(")) {
                        strSQL = strSQL.Substring(1);
                        var tmpans = TryParseSQLExpr(ref strSQL, ref attribs);
                        if (strSQL.StartsWith(")")) {
                            skipLen = 1;
                            state = ExprState.Function;
                        }
                        else
                            ans = false;
                    }
                    else if (strSQL.StartsWith("[Employee].")) { 
                        var attribMatch = Regex.Match(strSQL, @"\[Employee\].\[\w+\]");
                        if (attribMatch.Success) {
                            attribs.Add(attribMatch.Value);
                            skipLen = attribMatch.Value.Length;
                            state = ExprState.Function;
                        }
                        else
                            ans = false;
                    }
                    else if (strSQL.StartsWith("'")) {
                        var endOfConstant = strSQL.IndexOf('\'', 1);
                        if (endOfConstant > 0) {
                            skipLen = endOfConstant+1;
                            state = ExprState.Function;
                        }
                        else
                            ans = false;
                    }
                    else
                        ans = false;
                    break;
                case ExprState.Function:
                    var strSqlCopy = strSQL;
                    var fn = functions.Where(f => strSqlCopy.StartsWith(f)).FirstOrDefault();
                    if (fn != null) {
                        skipLen = fn.Length;
                        state = ExprState.Expression;
                    }
                    else
                        ans = false;
                    break;
            }
            strSQL = strSQL.Substring(skipLen);
        }
    
        return ans;
    }
