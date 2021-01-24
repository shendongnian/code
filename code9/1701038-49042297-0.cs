    public class SumLargest: ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 2);
            //n largest values
            var n = ArgToInt(arguments, 1);
            var cells = ArgsToDoubleEnumerable(arguments, context);
            var values = cells.ToList();
            values.RemoveAt(values.Count() - 1);
            var result = values
                .OrderByDescending(x => x)              
                .Take(n)
                .Sum();
            return CreateResult(result, DataType.Decimal);
        }
    }
