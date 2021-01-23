    public static class ExtensionFunction
    {
        public static T GetComponentInChildren<T>(this GameObject gameObject, int index)
        {
            return gameObject.transform.GetChild(index).GetComponent<T>();
        }
    }
