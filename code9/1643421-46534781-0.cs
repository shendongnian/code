    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using System.IO;
    
    
    public class ImageRead : MonoBehaviour {
    
        string url;
       
        public void readmyurl()
        {
        
               url = "file:///sdcard/Android/data/f8.txt";
            
           
        }
    
        private void Start()
        {
     
            StartCoroutine(file_read());
    
        }
    
        IEnumerator file_read()
        {
            readmyurl();
            yield return 0;
            WWW imgLink = new WWW(url);
            yield return imgLink;
            message1 = imgLink.text; //message1 is the content of file f8
    
        }
    
    
    
    }
