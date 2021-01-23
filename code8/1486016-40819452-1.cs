    class filterItem {
        public filterItem(string field, string op, object value) {
            this.Field = field;
            this.Operator = op;
            this.Value = value;
        }
        public string Field { get; private set; }
        public string Operator { get; private set; }
        public object Value { get; private set; }
    }
