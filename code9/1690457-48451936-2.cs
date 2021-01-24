    public class ConstantEvaluator : IJTokenEvaluator
    {
        private string k;
        public ConstantEvaluator(string k)
        {
            this.k = k;
        }
        public JToken Evaluate()
        {
            return JToken.Parse(k);
        }
    }
    public class DecimalConstantEvaluator : IJTokenEvaluator
    {
        private decimal @decimal;
        public DecimalConstantEvaluator(decimal @decimal)
        {
            this.@decimal = @decimal;
        }
        public JToken Evaluate()
        {
            return JToken.FromObject(@decimal);
        }
    }
    public class StringConstantEvaluator : IJTokenEvaluator
    {
        private string text;
        public StringConstantEvaluator(string text)
        {
            this.text = text;
        }
        public JToken Evaluate()
        {
            return text;
        }
    }
    public interface IJTokenEvaluator
    {
        JToken Evaluate();
    }
    public class FunctionEvaluator : IJTokenEvaluator
    {
        private string name;
        private IJTokenEvaluator[] parameters;
        private ExpressionParser evaluator;
        public FunctionEvaluator(ExpressionParser evaluator, string name, IJTokenEvaluator[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
            this.evaluator = evaluator;
        }
        public JToken Evaluate()
        {
            return evaluator.Evaluate(name, parameters.Select(p => p.Evaluate()).ToArray());
        }
    }
    public class ExpressionParser
    {
        public readonly Parser<IJTokenEvaluator> Function;
        public readonly Parser<IJTokenEvaluator> Constant;
        private static readonly Parser<char> DoubleQuote = Parse.Char('"');
        private static readonly Parser<char> Backslash = Parse.Char('\\');
        private static readonly Parser<char> QdText =
            Parse.AnyChar.Except(DoubleQuote);
        private static readonly Parser<char> QuotedPair =
            from _ in Backslash
            from c in Parse.AnyChar
            select c;
        private static readonly Parser<StringConstantEvaluator> QuotedString =
            from open in DoubleQuote
            from text in QdText.Many().Text()
            from close in DoubleQuote
            select new StringConstantEvaluator(text);
        public Dictionary<string, Func<JToken[], JToken>> Functions { get; set; } = new Dictionary<string, Func<JToken[], JToken>>();
        private readonly Parser<IJTokenEvaluator> Number = from op in Parse.Optional(Parse.Char('-').Token())
                                                           from num in Parse.Decimal
                                                           from trailingSpaces in Parse.Char(' ').Many()
                                                           select new DecimalConstantEvaluator(decimal.Parse(num) * (op.IsDefined ? -1 : 1));
        public ExpressionParser()
        {
            Function = from name in Parse.Letter.AtLeastOnce().Text()
                       from lparen in Parse.Char('(')
                       from expr in Parse.Ref(() => Function.Or(Number).Or(QuotedString).Or(Constant)).DelimitedBy(Parse.Char(',').Token())
                       from rparen in Parse.Char(')')
                       select CallFunction(name, expr.ToArray());
            Constant = Parse.LetterOrDigit.AtLeastOnce().Text().Select(k => new ConstantEvaluator(k));
        }
        public JToken Evaluate(string name, params JToken[] arguments)
        {
            return Functions[name](arguments);
        }
        IJTokenEvaluator CallFunction(string name, IJTokenEvaluator[] parameters)
        {
            return new FunctionEvaluator(this, name, parameters);
        }
        public JToken Evaluate(string str)
        {
            var stringParser = //Apparently the name 'string' was taken...
                 from first in Parse.Char('[')
                 from text in this.Function
                 from last in Parse.Char(']')
                 select text;
            var func = stringParser.Parse(str);
            return func.Evaluate();
        }
    }
