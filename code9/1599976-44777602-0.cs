    public class UICollection : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] elements;
        private bool visible;
        public bool Visible
        {
            get { return visible; }
        }
        public void Show()
        {
            foreach (GameObject item in elements)
            {
                item.SetActive(true);
            }
        }
        public void Hide()
        {
            foreach (GameObject item in elements)
            {
                item.SetActive(false);
            }
        }
    }
