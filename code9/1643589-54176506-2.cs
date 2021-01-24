     public class CallerObject : MonoBehaviour
    {
        public void Caller()
        {
            String imagePath = Application.persistentDataPath + "/image.png";
            StartCoroutine(captureScreenshot(imagePath));
        }
       
        IEnumerator captureScreenshot(String imagePath)
        {
            yield return new WaitForEndOfFrame();
            //about to save an image capture
            Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
            //Get Image from screen
            screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenImage.Apply();
            Debug.Log(" screenImage.width" + screenImage.width + " texelSize" + screenImage.texelSize);
            //Convert to png
            byte[] imageBytes = screenImage.EncodeToPNG();
            Debug.Log("imagesBytes=" + imageBytes.Length);
            //Save image to file
            System.IO.File.WriteAllBytes(imagePath, imageBytes);
        }
    }
   
