    public class BasicScreenShot: MonoBehaviour 
    {
        public string title="screencap";
        public int count;
        public BasicScreenShot()
        {
            // this gets the last value stored on the device
            count = PlayerPrefs.GetInt("screencapCount");
        }
        public void CapScrn() 
        {
            count++;
            Application.CaptureScreenshot(title + count + ".png");
            // ensure this value is saved onto the device
            PlayerPrefs.SetInt("screencapCount", count);
        }
    }
