    public class CollsionScript: MonoBehaviour 
    {
        ArcadeScore scoreSys;
        
        void Start()
        {
            //Find the ScoreSystem GameObject
            GameObject obj = GameObject.Find("ScoreSystem");
            //Get the ArcadeScore script
            scoreSys = obj.GetComponent<ArcadeScore >();
        }
        
        void OnCollisionEnter2D(Collision2D coll) 
        {
            if (coll.gameObject.tag == "YourOtherObject")
            {
                scoreSys.score++;
                //You can now destroy object
                Destroy(gameObject);
            }
        }
    }
