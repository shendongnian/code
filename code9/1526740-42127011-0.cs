    namespace EXT
    {
        public class PlayerPrefs
        {
            public static void AddInt(string key, int numberToAdd)
            {
                //Check if the key exist
                if (UnityEngine.PlayerPrefs.HasKey(key))
                {
                    //Read old value
                    int value = UnityEngine.PlayerPrefs.GetInt(key);
    
                    //Increment
                    value += numberToAdd;
    
                    //Save it back
                    UnityEngine.PlayerPrefs.SetInt(key, value);
                }
            }
    
            public static void SubstractInt(string key, int numberToSubstract)
            {
                //Check if the key exist
                if (UnityEngine.PlayerPrefs.HasKey(key))
                {
                    //Read old value
                    int value = UnityEngine.PlayerPrefs.GetInt(key);
    
                    //De-Increment
                    value -= numberToSubstract;
    
                    //Save it back
                    UnityEngine.PlayerPrefs.SetInt(key, value);
                }
            }
        }
    }
