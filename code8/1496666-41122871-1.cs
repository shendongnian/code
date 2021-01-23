    [System.Serializable]
    class GetBAResult
    {
        public List<bounceAbilityData> data;
    }
    [System.Serializable]
    class bounceAbilityData
    {
        public int id;
        public string name;
        public List<BaseAbilities> baseAbilities;
    }
    [System.Serializable]
    class BaseAbilities
    {
        public int baseId;
        public string name;
    }
