    [Serializable] 
    public class MaterialJson 
    { 
        public double timestamp; 
        public string profileId; 
        public string profileName; 
        Textures texture; 
    } 
    [Serializable] 
    public class Textures 
    { 
        Material material; 
    } 
    
    [Serializable] 
    public class Material 
    { 
        public string url; 
    }
