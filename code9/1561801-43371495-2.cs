        public void Main()
        {
            bool fireAgain = false;
            string message = "{0}::{1} : {2}";
            foreach (var item in Dts.Variables)
            {
                Dts.Events.FireInformation(0, "SCR Echo Back", string.Format(message, item.Namespace, item.Name, item.Value), string.Empty, 0, ref fireAgain);
            }
            Dts.TaskResult = (int)ScriptResults.Success;
        }
