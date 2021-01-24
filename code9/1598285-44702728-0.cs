    namespace Assets
    {
        class Deck : MonoBehaviour
        {
            [SerializeField]
            private GameObject[] deck;
            private GameObject[] instanciatedObjects;
            private void Start()
            {
                Fill();
            }
            public void Fill()
            {
                instanciatedObjects = new GameObject[deck.Length];
                for (int i = 0; i < deck.Lenght; i++)
                {
                    instanciatedObjects[i] = Instanciated(deck[i]) as GameObject;
                }
            }
        }
    }
