    public class Foo:MonoBehaviour{
         private static HashSet<Transform>fooCollection;
         private void Awake()
         {
              if(fooCollection  == null)
              {
                  fooCollection = new HashSet<Transform>(); 
              }
              fooCollection.Add(this.transform);
         }
         private void OnDestroy()
         {
              fooCollection.Remove(this.transform);
         }
         public static bool CompareFooObject(Transform tr)
         {
              if(tr == null) return false;
              return fooCollection.Contains(tr);
         }
    }
