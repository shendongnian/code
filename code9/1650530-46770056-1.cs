    public abstract class IMove : MonoBehaviour{
        public abstract void Move();
    }
    
    public sealed class Main_player:MonoBehaviour: IMove{
         public override void Move(){}
    }
    public sealed class Computer_player:MonoBehaviour: IMove{
         public override void Move(){}
    }
