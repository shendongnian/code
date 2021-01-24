    public class LoadImageFromUrl : MonoBehaviour {
    public string url;
    public void Download()
    {
        StartCoroutine(DownloadRoutine());
    }
    // Use this for initialization
    IEnumerator DownloadRoutine () {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;
    }
    }
