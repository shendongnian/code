    public class ScriptMain : UserComponent
    {
  
        Dictionary<string, string> AllCons = new Dictionary<string, string>();
        public override void PostExecute()
        {
            base.PostExecute();
            string connectionString;
            foreach (IDTSVariable100 obj in ReadWriteVariables)
            {
                if (AllCons.TryGetValue(obj.QualifiedName, out connectionString))
                {
                    obj.Value = connectionString;
                }
            }
        }
        public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            AllCons.Add("User::" + Row.ConName, Row.ConString);
        }
    }
