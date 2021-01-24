    using System.Collections.Generic;
    using UnityEngine;
    
    public class Encryption : MonoBehaviour {
    
        public string testString = "Every lower case vowel gets replaced by the 'next' vowel.";
    
        Dictionary<char, char> charMap;
        string result = "";
    
        void Start () {
            
            charMap = new Dictionary<char, char>() {
                {'a','e'},
                {'e','i'},
                {'i','o'},
                {'o','u'},
                {'u','a'}
            };
            result = "";    
            for (int i = 0; i < testString.Length; i++) {
    
                result += charMap.ContainsKey(testString[i]) ? charMap[testString[i]] : testString[i];
            }
    
            Debug.Log(result);
        }
    
    }
