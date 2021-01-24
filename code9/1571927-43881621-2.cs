    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ScreenPointPixel : MonoBehaviour
    {
        [DllImport("ScreenPointPixel-lib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initScreenPointPixel(IntPtr buffer, int x, int y, int width, int height);
        //-------------------------------------------------------------------------------------
        [DllImport("ScreenPointPixel-lib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void updateScreenPointPixelBufferPointer(IntPtr buffer);
        //-------------------------------------------------------------------------------------
        [DllImport("ScreenPointPixel-lib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void updateScreenPointPixelCoordinate(int x, int y);
        //-------------------------------------------------------------------------------------
        [DllImport("ScreenPointPixel-lib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void updateScreenPointPixelSize(int width, int height);
        //-------------------------------------------------------------------------------------
    
        //-------------------------------------------------------------------------------------
        [DllImport("ScreenPointPixel-lib", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetRenderEventScreenPointPixelFunc();
        //-------------------------------------------------------------------------------------
        int width = 500;
        int height = 500;
    
        //Where Pixel data will be saved
        byte[] screenData;
        //Where handle that pins the Pixel data will stay
        GCHandle pinHandler;
    
        //Used to test the color
        public RawImage rawImageColor;
    
        // Use this for initialization
        void Awake()
        {
            Resolution res = Screen.currentResolution;
            width = res.width;
            height = res.height;
    
            //Allocate array to be used
            screenData = new byte[width * height * 4];
    
            //Pin the Array so that it doesn't move around
            pinHandler = GCHandle.Alloc(screenData, GCHandleType.Pinned);
    
            //Register the screenshot and pass the array that will receive the pixels
            IntPtr arrayPtr = pinHandler.AddrOfPinnedObject();
    
            initScreenPointPixel(arrayPtr, 0, 0, width, height);
    
            StartCoroutine(caller());
        }
    
        IEnumerator caller()
        {
            while (true)
            {
                //Use mouse position as the pixel position
                //Input.tou
    
    
    #if UNITY_ANDROID || UNITY_IOS || UNITY_WSA_10_0
                if (!(Input.touchCount > 0))
                {
                    yield return null;
                    continue;
                }
    
                //Use touch position as the pixel position
                int x = Mathf.FloorToInt(Input.GetTouch(0).position.x);
                int y = Mathf.FloorToInt(Input.GetTouch(0).position.y);
    #else
                //Use mouse position as the pixel position
                int x = Mathf.FloorToInt(Input.mousePosition.x);
                int y = Mathf.FloorToInt(Input.mousePosition.y);
    #endif
                //Change this to any location from the screen you want
                updateScreenPointPixelCoordinate(x, y);
    
                //Must be 1 and 1
                updateScreenPointPixelSize(1, 1);
    
                //Take screenshot of the screen
                GL.IssuePluginEvent(GetRenderEventScreenPointPixelFunc(), 1);
    
                //Get the Color
                Color32 tempColor = new Color32();
                tempColor.r = screenData[0];
                tempColor.g = screenData[1];
                tempColor.b = screenData[2];
                tempColor.a = screenData[3];
    
                //Test it by assigning it to a raw image
                rawImageColor.color = tempColor;
    
                //Wait for a frame
                yield return null;
            }
        }
    
        void OnDisable()
        {
            //Unpin the array when disabled
            pinHandler.Free();
        }
    }
