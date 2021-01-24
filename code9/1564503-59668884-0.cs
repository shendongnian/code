    GUI.DrawTexture(screenRect, webCamTexture, ScaleMode.ScaleToFit);
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(webCamTexture.GetPixels32(),
                    webCamTexture.width, webCamTexture.height);
                if (result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                    loadNewPoi(Convert.ToInt32(result.Text));
                    PlayerPrefs.SetInt("camera_enabled", Convert.ToInt32(false));
                    webCamTexture.Stop();
                }
            }
