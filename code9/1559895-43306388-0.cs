    public class MultiComponentAdder : MonoBehaviour {
      List<Type> types = new List<Type>();
    
      void Awake () {
      	types.Add(typeof(Apple));
      	types.Add(typeof(Orange));
      	types.Add(typeof(Banana));
    
      	foreach (var t in types)
      	{
      		this.gameObject.AddComponent(t);
      	}
      }
    }
