    public abstract class IMove : MonoBehaviour{
        public abstract void Move();
    }
    
    public sealed class Main_player: IMove{
         public override void Move(){}
    }
    public sealed class Computer_player: IMove{
         public override void Move(){}
    }
