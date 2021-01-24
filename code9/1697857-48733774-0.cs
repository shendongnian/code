    public class FaceRectangle
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class HeadPose
    {
        public double pitch { get; set; }
        public double roll { get; set; }
        public double yaw { get; set; }
    }
    public class FacialHair
    {
        public double moustache { get; set; }
        public double beard { get; set; }
        public double sideburns { get; set; }
    }
    public class Emotion
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }
    }
    public class Blur
    {
        public string blurLevel { get; set; }
        public double value { get; set; }
    }
    public class Exposure
    {
        public string exposureLevel { get; set; }
        public double value { get; set; }
    }
    public class Noise
    {
        public string noiseLevel { get; set; }
        public double value { get; set; }
    }
    public class Makeup
    {
        public bool eyeMakeup { get; set; }
        public bool lipMakeup { get; set; }
    }
    public class Occlusion
    {
        public bool foreheadOccluded { get; set; }
        public bool eyeOccluded { get; set; }
        public bool mouthOccluded { get; set; }
    }
    public class HairColor
    {
        public string color { get; set; }
        public double confidence { get; set; }
    }
    public class Hair
    {
        public double bald { get; set; }
        public bool invisible { get; set; }
        public IList<HairColor> hairColor { get; set; }
    }
    public class FaceAttributes
    {
        public double smile { get; set; }
        public HeadPose headPose { get; set; }
        public string gender { get; set; }
        public double age { get; set; }
        public FacialHair facialHair { get; set; }
        public string glasses { get; set; }
        public Emotion emotion { get; set; }
        public Blur blur { get; set; }
        public Exposure exposure { get; set; }
        public Noise noise { get; set; }
        public Makeup makeup { get; set; }
        public IList<object> accessories { get; set; }
        public Occlusion occlusion { get; set; }
        public Hair hair { get; set; }
    }
    public class AzureFace 
    {
        public string faceId { get; set; }
        public FaceRectangle faceRectangle { get; set; }
        public FaceAttributes faceAttributes { get; set; }
    }
