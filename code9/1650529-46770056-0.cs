    public interface IMove{
        void Move();
    }
    
    public class Main_player:MonoBehaviour: IMove{
         public void Move(){}
    }
    public class Computer_player:MonoBehaviour: IMove{
         public void Move(){}
    }
