    using UnityEngine;
    using System.Collections;
    
    public class DelayedCamera : MonoBehaviour
    {
        public struct Frame
        {
            /// <summary>
            /// The texture representing the frame
            /// </summary>
            private Texture2D texture;
    
            /// <summary>
            /// The time (in seconds) the frame has been captured at
            /// </summary>
            private float recordedTime;
    
            /// <summary>
            /// Captures a new frame using the given render texture
            /// </summary>
            /// <param name="renderTexture">The render texture this frame must be captured from</param>
            public void CaptureFrom( RenderTexture renderTexture )
            {
                RenderTexture.active = renderTexture;
    
                // Create a new texture if none have been created yet in the given array index
                if ( texture == null )
                    texture = new Texture2D( renderTexture.width, renderTexture.height );
    
                // Save what the camera sees into the texture
                texture.ReadPixels( new Rect( 0, 0, renderTexture.width, renderTexture.height ), 0, 0 );
                texture.Apply();
    
                recordedTime = Time.time;
    
                RenderTexture.active = null;
            }
    
            /// <summary>
            /// Indicates whether the frame has been captured before the given time
            /// </summary>
            /// <param name="time">The time</param>
            /// <returns><c>true</c> if the frame has been captured before the given time, <c>false</c> otherwise</returns>
            public bool CapturedBefore( float time )
            {
                return recordedTime < time;
            }
    
            /// <summary>
            /// Operator to convert the frame to a texture
            /// </summary>
            /// <param name="frame"></param>
            public static implicit operator Texture2D( Frame frame ) { return frame.texture; }
        }
    
        /// <summary>
        /// The camera used to capture the frames
        /// </summary>
        [SerializeField]
        private Camera renderCamera;
    
        /// <summary>
        /// The delay
        /// </summary>
        [SerializeField]
        private float delay = 0.5f;
    
        /// <summary>
        /// The size of the buffer containing the recorded images
        /// </summary>
        /// <remarks>
        /// Try to keep this value as low as possible according to the delay
        /// </remarks>
        private int bufferSize = 256;
    
        /// <summary>
        /// The render texture used to record what the camera sees
        /// </summary>
        private RenderTexture renderTexture;
    
        /// <summary>
        /// The recorded frames
        /// </summary>
        private Frame[] frames;
    
        /// <summary>
        /// The index of the captured texture
        /// </summary>
        private int capturedFrameIndex;
    
        /// <summary>
        /// The index of the rendered texture
        /// </summary>
        private int renderedFrameIndex;
    
        /// <summary>
        /// The frame index
        /// </summary>
        private int frameIndex;
        
        private void Awake()
        {
            frames = new Frame[bufferSize];
    
            // Change the depth value from 24 to 16 may improve performances. And try to specify an image format with better compression.
            renderTexture = new RenderTexture( Screen.width, Screen.height, 24 );
            renderCamera.targetTexture = renderTexture;
            StartCoroutine( Render() );
        }
    
        /// <summary>
        /// Makes the camera render with a delay
        /// </summary>
        /// <returns></returns>
        private IEnumerator Render()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
    
            while ( true )
            {
                yield return wait;
    
                capturedFrameIndex = frameIndex % bufferSize;
    
                frames[capturedFrameIndex].CaptureFrom( renderTexture );
    
                // Find the index of the frame to render
                // The foor loop is **voluntary** empty
                for ( ; frames[renderedFrameIndex].CapturedBefore( Time.time - delay ) ; renderedFrameIndex = ( renderedFrameIndex + 1 ) % bufferSize ) ;
                
                Graphics.Blit( frames[renderedFrameIndex], null as RenderTexture );
    
                frameIndex++;
            }
        }
    }
