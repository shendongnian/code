    [System.Serializable]
    public class SaveManager {
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context) {
            version = 1.5f;
            resolutionSetting = 1;
            notificationTimer = 5 * 60;
            hideNameTagTimer = 0 * 60;
            storedLevelName = "little_transparent";
            fartVolume = 0f;
            fartToggle = true;
            nametagsCollideWithCharacters = true;
        }
        [OptionalField]
        public float version = 1.5f;
