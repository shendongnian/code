    static GameManager _instance;
        public static GameManager instance {
            get {
                if (!_instance) {
                    _instance = FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
