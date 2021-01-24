    public IEnumerator DownloadTextFile()
    {
       WWW version = new WWW(myLink);
       yield return version;
       File.WriteAllBytes("version.txt", version.bytes);
       //Or if you just wanted the text in your game instead of a file
       someTextObject.text = version.text;
    }
