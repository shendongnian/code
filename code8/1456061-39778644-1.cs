        public void Main()
        {
            try
            {
                string value = Dts.Variables["$Package::ExchangePassword"].GetSensitiveValue().ToString();
 
                Dts.TaskResult = (int)ScriptResults.Success;
            }
            catch (Exception e)
            {
                Dts.Log(e.Message, 0, null);
                Dts.TaskResult = (int)ScriptResults.Failure;
            }
        }
