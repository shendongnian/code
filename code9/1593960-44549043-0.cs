    using UnityEngine;
    using UnityEngine.UI;
    [RequireComponent(typeof(RectTransform))]
    public class TestScript: MonoBehaviour
    {
        [SerializeField]
        private float m_BubbleSize;
        [SerializeField]
        private int m_BubbleColumns;
        [SerializeField]
        private int m_BubbleRows;
        [SerializeField]
        private Sprite[] m_BubbleSprites;
        private GameObject[][] m_Bubbles;
        void Start()
        {
            GenerateBubbles();
        }
        private void GenerateBubbles()
        {
            // Position of the most top left bubble
            Vector3 initialPosition = GetComponent<RectTransform>().position;
            initialPosition.y += GetComponent<RectTransform>().rect.height * 0.5f;
            initialPosition.y -= 0.5f * m_BubbleSize;
            initialPosition.x -= (m_BubbleColumns - 1) * 0.5f * m_BubbleSize;
            initialPosition.x -= 0.25f * m_BubbleSize;
            // Rows height: comes from https://en.wikipedia.org/wiki/Close-packing_of_equal_spheres
            float rowsHeight = Mathf.Sqrt(6.0f * m_BubbleSize * m_BubbleSize) / 3.0f;
            // Bubbles references array
            m_Bubbles = new GameObject[m_BubbleColumns][];
            for(int i = 0; i < m_Bubbles.Length; i++)
            {
                m_Bubbles[i] = new GameObject[m_BubbleRows];
            }
            // Generation
            for(int x = 0; x < m_Bubbles.Length; x++)
            {
                for(int y = 0; y < m_Bubbles[x].Length; y++)
                {
                    GameObject bubble = new GameObject("Bubble_" + x.ToString() + y.ToString(), new System.Type[] { typeof(RectTransform), typeof(Image), typeof(CircleCollider2D) });
                    bubble.transform.SetParent(transform);
                    if(y % 2 == 0)
                    {
                        bubble.GetComponent<RectTransform>().position = initialPosition + new Vector3(x * m_BubbleSize, -y * rowsHeight, 0.0f);
                    }
                    else
                    {
                        bubble.GetComponent<RectTransform>().position = initialPosition + new Vector3(0.5f * m_BubbleSize + x * m_BubbleSize, -y * rowsHeight, 0.0f);
                    }
                    bubble.GetComponent<RectTransform>().sizeDelta = new Vector2(m_BubbleSize, m_BubbleSize);
                    bubble.GetComponent<Image>().sprite = m_BubbleSprites[Random.Range(0, m_BubbleSprites.Length)];
                    bubble.GetComponent<CircleCollider2D>().radius = m_BubbleSize * 0.5f;
                }
            }
        }
    }
