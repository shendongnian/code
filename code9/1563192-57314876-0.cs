    using System;
    using System.Collections;
    using System.IO;
    using UnityEngine;
    using UnityEngine.Networking;
    
    public class ImageDownloader : MonoBehaviour
    {
    
        private void Start()
        {
            //File url
            string url = "https://www.stickpng.com/assets/images/58482b92cef1014c0b5e4a2d.png";
            //Save Path
            string savePath = Path.Combine(Application.persistentDataPath, "data");
            savePath = Path.Combine(savePath, "Images");
            savePath = Path.Combine(savePath, "logo.png");
            downloadImage(url,savePath);
        }
        public void downloadImage(string url, string pathToSaveImage)
        {
            StartCoroutine(_downloadImage(url,pathToSaveImage));
        }
    
        private IEnumerator _downloadImage(string url, string savePath)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
            {
                yield return uwr.SendWebRequest();
    
                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.LogError(uwr.error);
                }
                else
                {
                    Debug.Log("Success");
                    Texture myTexture = DownloadHandlerTexture.GetContent(uwr);
                    byte[] results = uwr.downloadHandler.data;
                    saveImage(savePath, results);
                    
                }
            }
        }
    
        void saveImage(string path, byte[] imageBytes)
        {
            //Create Directory if it does not exist
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
    
            try
            {
                File.WriteAllBytes(path, imageBytes);
                Debug.Log("Saved Data to: " + path.Replace("/", "\\"));
            }
            catch (Exception e)
            {
                Debug.LogWarning("Failed To Save Data to: " + path.Replace("/", "\\"));
                Debug.LogWarning("Error: " + e.Message);
            }
        }
    
        byte[] loadImage(string path)
        {
            byte[] dataByte = null;
    
            //Exit if Directory or File does not exist
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Debug.LogWarning("Directory does not exist");
                return null;
            }
    
            if (!File.Exists(path))
            {
                Debug.Log("File does not exist");
                return null;
            }
    
            try
            {
                dataByte = File.ReadAllBytes(path);
                Debug.Log("Loaded Data from: " + path.Replace("/", "\\"));
            }
            catch (Exception e)
            {
                Debug.LogWarning("Failed To Load Data from: " + path.Replace("/", "\\"));
                Debug.LogWarning("Error: " + e.Message);
            }
    
            return dataByte;
        }
    }
