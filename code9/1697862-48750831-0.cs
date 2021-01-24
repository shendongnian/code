     [System.Serializeable]
     public class Test {
         int value = 500;
     }
     public class TestManager : MonoBehaviour {
         public Test testInt;
         public List<Test> testInts;
         void Reset(){
             testInts = new List<Test>(){
                 new Test()
             };
         }
     }
