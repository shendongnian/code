    public class PlatformCreator : MonoBehaviour {
     public GameObject[] platforms;
     public List<Transform> points;
     private Random rng; 
     public void Shuffle<T>(this IList<T> list)  
     {  
        int n = list.Count;  
        while (n > 1) {  
        n--;  
        int k = rng.Next(n + 1);  
        T value = list[k];  
        list[k] = list[n];  
        list[n] = value;  
        }  
     }
     private void Start()
     {
        rng = new Random(); 
        points.Shuffle();
        for (int i = 0; i < points.Count; i++)
        {
            Instantiate(platforms[i], points[i].position, Quaternion.identity);
        }
     }
    }
