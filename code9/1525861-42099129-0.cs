    public class LesserSlime : BaseUnityEnemy {
        // Use this for initialization
        void Start () {
            myEnemy = new BaseEnemy(1, 5, 5, 5, 5, 5, 5, 5);
            myEnemy.IsSelected = false;        
        }
    }
