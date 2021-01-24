    using UnityEngine;
    using System.Collections;
    using System.IO;
    using UnityEngine.UI;
    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Collections.Generic;
    
    public class Connecting : MonoBehaviour
    {
        WebCamTexture webCam;
        public RawImage myImage;
        public bool enableLog = false;
    
        Texture2D currentTexture;
    
        private TcpListener listner;
        private const int port = 8010;
        private bool stop = false;
    
        private List<TcpClient> clients = new List<TcpClient>();
    
        //This must be the-same with SEND_COUNT on the client
        const int SEND_RECEIVE_COUNT = 15;
    
        private void Start()
        {
            Application.runInBackground = true;
    
            //Start WebCam coroutine
            StartCoroutine(initAndWaitForWebCamTexture());
        }
    
    
        //Converts the data size to byte array and put result to the fullBytes array
        void byteLengthToFrameByteArray(int byteLength, byte[] fullBytes)
        {
            //Clear old data
            Array.Clear(fullBytes, 0, fullBytes.Length);
            //Convert int to bytes
            byte[] bytesToSendCount = BitConverter.GetBytes(byteLength);
            //Copy result to fullBytes
            bytesToSendCount.CopyTo(fullBytes, 0);
        }
    
        //Converts the byte array to the data size and returns the result
        int frameByteArrayToByteLength(byte[] frameBytesLength)
        {
            int byteLength = BitConverter.ToInt32(frameBytesLength, 0);
            return byteLength;
        }
    
        IEnumerator initAndWaitForWebCamTexture()
        {
            // Open the Camera on the desired device, in my case IPAD pro
            webCam = new WebCamTexture();
            // Get all devices , front and back camera
            webCam.deviceName = WebCamTexture.devices[WebCamTexture.devices.Length - 1].name;
    
            // request the lowest width and heigh possible
            webCam.requestedHeight = 10;
            webCam.requestedWidth = 10;
    
            myImage.texture = webCam;
    
            webCam.Play();
    
            currentTexture = new Texture2D(webCam.width, webCam.height);
    
            // Connect to the server
            listner = new TcpListener(IPAddress.Any, port);
    
            listner.Start();
    
            while (webCam.width < 100)
            {
                yield return null;
            }
    
            //Start sending coroutine
            StartCoroutine(senderCOR());
        }
    
        WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
        IEnumerator senderCOR()
        {
    
            bool isConnected = false;
            TcpClient client = null;
            NetworkStream stream = null;
    
            // Wait for client to connect in another Thread 
            Loom.RunAsync(() =>
            {
                while (!stop)
                {
                    // Wait for client connection
                    client = listner.AcceptTcpClient();
                    // We are connected
                    clients.Add(client);
    
                    isConnected = true;
                    stream = client.GetStream();
                }
            });
    
            //Wait until client has connected
            while (!isConnected)
            {
                yield return null;
            }
    
            LOG("Connected!");
    
            bool readyToGetFrame = true;
    
            byte[] frameBytesLength = new byte[SEND_RECEIVE_COUNT];
    
            while (!stop)
            {
                //Wait for End of frame
                yield return endOfFrame;
    
                currentTexture.SetPixels(webCam.GetPixels());
                byte[] pngBytes = currentTexture.EncodeToPNG();
                //Fill total byte length to send. Result is stored in frameBytesLength
                byteLengthToFrameByteArray(pngBytes.Length, frameBytesLength);
    
                //Set readyToGetFrame false
                readyToGetFrame = false;
    
                Loom.RunAsync(() =>
                {
                    //Send total byte count first
                    stream.Write(frameBytesLength, 0, frameBytesLength.Length);
                    LOG("Sent Image byte Length: " + frameBytesLength.Length);
    
                    //Send the image bytes
                    stream.Write(pngBytes, 0, pngBytes.Length);
                    LOG("Sending Image byte array data : " + pngBytes.Length);
    
                    //Sent. Set readyToGetFrame true
                    readyToGetFrame = true;
                });
    
                //Wait until we are ready to get new frame(Until we are done sending data)
                while (!readyToGetFrame)
                {
                    LOG("Waiting To get new frame");
                    yield return null;
                }
            }
        }
    
    
        void LOG(string messsage)
        {
            if (enableLog)
                Debug.Log(messsage);
        }
    
        private void Update()
        {
            myImage.texture = webCam;
        }
    
        // stop everything
        private void OnApplicationQuit()
        {
            if (webCam != null && webCam.isPlaying)
            {
                webCam.Stop();
                stop = true;
            }
    
            if (listner != null)
            {
                listner.Stop();
            }
    
            foreach (TcpClient c in clients)
                c.Close();
        }
    }
