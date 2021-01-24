     using UnityEngine;
     using System.Collections;
    
    public class Stats : MonoBehaviour 
    {
        StatContainer stats = new StatContainer();
    
        // Use this for initialization
        void Start () {
           InvokeRepeating ("AddCoins", 4.0f, 2.0f);
           InvokeRepeating ("AddScore", 1.5f, 1.5f);
        }
    
         // Update is called once per frame
        void Update () {
            this.stats.Update();
        }
    
        void AddCoins (){       
           stats.AddCoins();
        }
    
        void AddScore (){
           stats.AddScore();
        }
    }
    [Serializable]
    public class StatContainer
    {
        public int coins = 0;
        public int totalcoins = 0;
        public int score = 0;
        
        public int personalbest = 0;
        public float UmbrellaSpeed = 0.1f;
        public float currentumbdur = 500;
        
        public  int CarrotSpawnRateLVL = 1;
        public float CarrotSpawnRate = 60f;
        public int CarrotSpawnRateUpgradeCost = 15;
        
        // and the rest
        public void Update(){
           if (statscore > personalbest) {
                 personalbest = score;
           }
        }
    }
