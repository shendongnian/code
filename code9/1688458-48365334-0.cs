    public class TowerComponent: MonoBehaviour
    {
       public static Dictionary<TowerComponent, TowerType> currentTowers = 
          new Dictionary<TowerComponent, TowerType>();
       
       private void Awake()
       {
          currentTowers.Add(this, typeOfTower);
       }
    }
