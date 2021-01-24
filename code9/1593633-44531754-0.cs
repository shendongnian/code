    [System.Serializable]
    public class Item
    {
        //Will be ignored by JsonUtility but will be visible in the Editor
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private float _value;
        [SerializeField]
        private Vector3 position;
        [SerializeField]
        private Quaternion rotation;
        [SerializeField]
        private Vector3 scale;
        //Call before serializing
        public void updateValues()
        {
            position = _transform.position;
            rotation = _transform.rotation;
            scale = _transform.localScale;
        }
    }
