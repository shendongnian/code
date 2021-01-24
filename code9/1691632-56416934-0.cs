    public class AcadCommands
    {
        [CommandMethod("TriggerCmd")]
        public void TriggerCommand
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("Hi");
            Point2d p;
        }
    }
