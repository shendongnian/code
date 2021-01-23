    public class AlertModel {
        // Some things
        public override bool Equals(object model) {
            return model != null && CommandID == model.CommandId && AlertID == model.AlertID;
        }
    }
