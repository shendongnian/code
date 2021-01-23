    public class ImageLoader : MonoBehaviour
    {
        bool imageDone = false;
        private Texture2D _texInMemory = null;
    
        public Texture2D getImage()
        {
            return _texInMemory;
        }
    
        public bool imageReady()
        {
            return imageDone;
        }
    
        public void retrieveImage(string fileName)
        {
            if (!imageDone)
            {
                Debug.Log("Error: Image is still retrieving");
                return;
            }
    
            imageDone = false;
            StartCoroutine(loadImage(fileName));
        }
    
        private IEnumerator loadImage(string fileName)
        {
            var path = somestring;
            WWW uri = new WWW(path);
            yield return uri;
            _texInMemory = uri.texture;
    
            imageDone = true;
        }
    }
