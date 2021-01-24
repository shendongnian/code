    public class MyClass {
        const string REGEX_OPERATORS = "^(?<Id>.{4})(?<Name>.{40})(?<Password>.{5})";
        private readonly Regex reOperators = new Regex(REGEX_OPERATORS, RegexOptions.Compiled);
        private readonly IFileSystem File;
        private readonly IProjectContext context;
        public MyClass(IFileSystem File, IProjectContext context) {
            this.File = File;
            this.context = context;
        }
        public void ImportOperatorList() {
            var path = @"F:\testdata.txt";
            var lines = File.ReadAllLines(path);
            foreach (var line in lines) {
                var match = reOperators.Match(line);
                if (match.Success) {
                    string rawId = match.Groups["Id"].Value;
                    string rawName = match.Groups["Name"].Value;
                    string rawPassword = match.Groups["Password"].Value;
                    var op = new Operator {
                        Id = int.Parse(rawId, System.Globalization.NumberStyles.Integer),
                        Name = rawName,
                        Password = int.Parse(rawPassword, System.Globalization.NumberStyles.Integer)
                    };
                    context.Operators.Add(op);
                }
            }
            if (lines.Length > 0)
                Debug.WriteLine(context.SaveChanges());
        }
    }
