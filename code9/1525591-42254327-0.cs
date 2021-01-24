    class MySsisEvents : DefaultEvents
    {
        public int Rows { get; private set; }
        public override void OnVariableValueChanged(DtsContainer DtsContainer, Variable variable, ref bool fireAgain)
        {
            this.Rows = Convert.ToInt32(variable.Value);
        }
    }
