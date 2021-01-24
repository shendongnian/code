    public class SqlParser
    {
        public List<int> GetQueriedCurveIds(string sql)
        {
            var parser = new TSql120Parser(false);
    
            IList<ParseError> errors;
            var fragment = parser.Parse(new StringReader(sql), out errors);
    
            List<int> curveIds = new List<int>();
            CurveIdVisitor cidv = new CurveIdVisitor();
            InPredicateVisitor inpv = new InPredicateVisitor();
            fragment.AcceptChildren(cidv);
            fragment.AcceptChildren(inpv);
    
            curveIds.AddRange(cidv.CurveIds);
            curveIds.AddRange(inpv.CurveIds);
            return curveIds.Distinct().ToList();
        }
    }
    
    
    
    class CurveIdVisitor : TSqlConcreteFragmentVisitor
    {
        public readonly List<int> CurveIds = new List<int>();
    
        public override void Visit(BooleanComparisonExpression exp)
        {
            if (exp.FirstExpression is ColumnReferenceExpression && exp.SecondExpression is IntegerLiteral )
            {
                //  there is a possibility that this is of the ilk 'curveid = 123'
                //  we will look for the 'identifier'
                //  we take the last if there are multiple.  Example:
                //      alias.curveid
                //  goives two identifiers: alias and curveid
                if (
                    ((ColumnReferenceExpression) exp.FirstExpression).MultiPartIdentifier.Identifiers.Last().Value.ToLower() ==
                    "curveid")
                {
                    //  this is definitely a curveid filter
                    //  Now to find the curve id
                    int curveid = int.Parse(((IntegerLiteral) exp.SecondExpression).Value);
                    CurveIds.Add(curveid);
                }
            }
        }
    }
    
    class InPredicateVisitor : TSqlConcreteFragmentVisitor
    {
        public readonly List<int> CurveIds = new List<int>();
    
        public override void Visit(InPredicate exp)
        {
            if (exp.Expression is ColumnReferenceExpression)
            {
                if (
                    ((ColumnReferenceExpression) exp.Expression).MultiPartIdentifier.Identifiers.Last().Value.ToLower() ==
                    "curveid")
                {
                    foreach (var value in exp.Values)
                    {
                        if (value is IntegerLiteral)
                        {
                            CurveIds.Add(int.Parse(((IntegerLiteral)value).Value));
                        }
                    }
                }
            }
        }
    }
