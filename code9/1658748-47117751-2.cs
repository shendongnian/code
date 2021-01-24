    public void PrepareServerData(Texture2D[] texToSend, string typeToSend)
        {
            StartCoroutine(DoGetTexToBytes(texToSend, 0));
            // Other stuff
        }
    IEnumerator DoGetTexToBytes(Texture2D[] tex, int arrayIndex)
        {
            yield return StartCoroutine(DoResizeTex(tex, arrayIndex));
    
            // Stuff done by DoGetTexToBytes after DoResizeTex has finished
        }
    IEnumerator DoResizeTex(Texture2D[] tex, int arrayIndex)
        {
            tex[arrayIndex].ResizePro(1280, 1024);
            tex[arrayIndex].Apply();
    
            yield return new WaitForEndOfFrame();
        }
