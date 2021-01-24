    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class TestScript : MonoBehaviour
    {
        public Image m_DisplayImage;
        public Sprite m_Sprite1, m_Sprite2;
	    void Update()
	    {
	        if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(CombineSpritesCoroutine());
            }
	    }
        private IEnumerator CombineSpritesCoroutine()
        {
            Sprite[][] spritesToCombine = new Sprite[4][];
            for (int i = 0; i < spritesToCombine.Length; i++)
            {
                spritesToCombine[i] = new Sprite[4];
            }
            for (int x = 0; x < spritesToCombine.Length; x++)
            {
                for (int y = 0; y < spritesToCombine[x].Length; y++)
                {
                    spritesToCombine[x][y] = ((x + y) % 2 == 0 ? m_Sprite1 : m_Sprite2);
                }
            }
            Sprite finalSprite = null;
            yield return finalSprite = CombineSpriteArray(spritesToCombine);
            m_DisplayImage.sprite = finalSprite;
        }
        public Sprite CombineSpriteArray(Sprite[][] spritesArray)
        {
            // Set those two or get them from one the the sprites you want to combine
            int spritesWidth = (int)spritesArray[0][0].rect.width;
            int spritesHeight = (int)spritesArray[0][0].rect.height;
            Texture2D combinedTexture = new Texture2D(spritesWidth * spritesArray.Length, spritesHeight * spritesArray[0].Length);
            for (int x = 0; x < spritesArray.Length; x++)
            {
                for (int y = 0; y < spritesArray[0].Length; y++)
                {
                    combinedTexture.SetPixels32(x * spritesWidth, y * spritesHeight, spritesWidth, spritesHeight, spritesArray[x][y].texture.GetPixels32());
                }
            }
            combinedTexture.Apply();
            return Sprite.Create(combinedTexture, new Rect(0.0f, 0.0f, combinedTexture.width, combinedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }
