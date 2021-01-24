    using UnityAsync;
    using System.Threading.Tasks;
    public class UpdateLoop : AsyncBehaviour
    {
        void Start()
        {
            RotateIndefinitely();
        }
    
        // IEnumerator replaced with async void
        async void DoNotRunEachFrame()
        {
            while(true)
            {
                print("Run Each frame right before rendering");
                //yield return null replaced with await NextUpdate()
                await NextUpdate();
            }
        }
    }
