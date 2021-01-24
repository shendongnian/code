    IEnumerator DoGetTexToBytes(Texture2D tex)
        {
            yield return StartCoroutine(DoResizeTex(tex));
    
            // Stuff done by DoGetTexToBytes after DoResizeTex has finished
        }
    IEnumerator DoResizeTex(Texture2D tex)
        {
            tex.ResizePro(1280, 1024);
            tex.Apply();
    
            yield return new WaitForEndOfFrame();
        }
