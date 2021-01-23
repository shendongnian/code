    public class SystemManager
    {
        public rkcPosition _position;
        //...
        public bool Move(int TargetID, int TargetDirection)
        {
            rkcPosition _position = GameManager.MainMap.GetPosition(TargetID);
        }
    }
