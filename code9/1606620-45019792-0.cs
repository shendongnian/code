    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class DelayedCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera renderCamera;
    
        private RenderTexture renderTexture;
    
        private Queue<Texture2D> frames;
        
        private void Awake()
        {
            frames = new Queue<Texture2D>();
            renderTexture = new RenderTexture( Screen.width, Screen.height, 24 );
            renderCamera.targetTexture = renderTexture;
            StartCoroutine( Render() );
        }
    
        private IEnumerator Render()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
    
            while ( true )
            {
                yield return wait;
    
                // Create new texture of the current frame
                RenderTexture.active = renderTexture;
                Texture2D texture = new Texture2D( renderTexture.width, renderTexture.height );
                texture.ReadPixels( new Rect( 0, 0, renderTexture.width, renderTexture.height ), 0, 0 );
                texture.Apply();
                RenderTexture.active = null;
    
                // Add it to the queue to "delay" the rendering
                frames.Enqueue( texture );
    
                // If the queue is too big, render the first frame on the screen
                if ( frames.Count > 100 )
                {
                    Graphics.Blit( frames.Dequeue(), null as RenderTexture );
                }
            }
        }
    }
