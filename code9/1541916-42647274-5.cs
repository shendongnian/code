    public class Test2 : MonoBehaviour
    {
    
        // Use this for initialization
    
        //Publics
        private string path = "file:///";
        public string folder = "C:/medias/";
        int interval = 7000;
        int arrLength;
        int i = 0;
    
        string source;
        string str;
        WWW www;
    
        string[] extensions = new[] { ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".ogg", ".OGG" };
    
        FileInfo[] info;
        DirectoryInfo dir;
    
        void Start()
        {
            dir = new DirectoryInfo(@folder);
            info = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
            arrLength = info.Length;
    
            StartCoroutine(looper());
        }
    
    
        IEnumerator looper()
        {
            yield return StartCoroutine(medialogic());
    
            WaitForSeconds waitTime = new WaitForSeconds(5);
    
            //Run forever
            while (true)
            {
    
                if (i == arrLength - 1)
                {
                    info = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
                    arrLength = info.Length;
                    i = 0;
                }
                else
                {
                    i++;
                }
                yield return StartCoroutine(medialogic());
    
                //Wait for 5 seconds 
                yield return waitTime;
            }
        }
    
        IEnumerator medialogic()
        {
            source = info[i].ToString();
            str = path + source;
            www = new WWW(str);
    
            //Wait for download to finish
            yield return www;
    
            string[] extType = source.Split('.');
            int pos = Array.IndexOf(extensions, "." + extType[1]);
            if (pos > -1)
            {
                GetComponent<RawImage>().texture = www.texture;
                Debug.Log(extType[1]);
            }
            else
            {
                //videos here
                Debug.Log(extType[1]);
            }
        }
    }
