    internal enum VariableViewType
    {
        Parameter,
        Declare
    }
    internal class VariableView
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public VariableViewType Type { get; set; }
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return $"{this.Type} {this.Name} {this.DataType}";
            }
            return base.ToString();
        }
    }
    internal class VariablesVisitor : TSqlFragmentVisitor
    {
        public IList<DeclareVariableStatement> DeclareVariables { get; private set; }
        public IList<ProcedureParameter> ProcedureParameters { get; private set; }
        public VariablesVisitor()
        {
            DeclareVariables = new List<DeclareVariableStatement>();
            ProcedureParameters = new List<ProcedureParameter>();
        }
        public override void ExplicitVisit(DeclareVariableStatement node)
        {
            DeclareVariables.Add(node);
        }
        public override void ExplicitVisit(ProcedureParameter node)
        {
            ProcedureParameters.Add(node);
        }
        public IList<VariableView> GetVariables()
        {
            var ret = new List<VariableView>();
            foreach (var statements in DeclareVariables)
            {
                foreach (var declare in statements.Declarations)
                {
                    ret.Add(new VariableView()
                    {
                        Name = declare.VariableName.Value,
                        DataType = declare.DataType.Name.Identifiers.Last().Value,
                        Type = VariableViewType.Declare
                    });
                }
            }
            foreach (var parameter in ProcedureParameters)
            {
                ret.Add(new VariableView()
                {
                    Name = parameter.VariableName.Value,
                    DataType = parameter.DataType.Name.Identifiers.Last().Value,
                    Type = VariableViewType.Parameter
                });
            }
            return ret;
        }
    }
