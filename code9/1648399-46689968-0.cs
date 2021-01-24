    public class CameraToSpriteMirror: MonoBehaviour
    {
        public SpriteRenderer spriteToUpdate;
        public Camera mirrorCam;
    
        void Start()
        {
            StartCoroutine(waitForCam());
        }
    
        WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
    
        IEnumerator waitForCam()
        {
            //Will run forever in this while loop
            while (true)
            {
                //Wait for end of frame
                yield return endOfFrame;
    
                //Get camera render texture
                RenderTexture rendText = RenderTexture.active;
                RenderTexture.active = mirrorCam.targetTexture;
    
                //Render that camera
                mirrorCam.Render();
    
                //Convert to Texture2D
                Texture2D text = renderTextureToTexture2D(mirrorCam.targetTexture);
    
                RenderTexture.active = rendText;
    
                //Convert to Sprite
                Sprite sprite = texture2DToSprite(text);
    
                //Apply to SpriteRenderer
                spriteToUpdate.sprite = sprite;
    
            }
        }
    
        Texture2D renderTextureToTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }
    
        Sprite texture2DToSprite(Texture2D text2D)
        {
            Sprite sprite = Sprite.Create(text2D, new Rect(0, 0, text2D.width, text2D.height), Vector2.zero);
            return sprite;
        }
    }
