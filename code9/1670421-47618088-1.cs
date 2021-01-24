    public class RandomColorTest
    {
        [Test]
        public void TestColorGeneration()
        {
            Color c = Color.magenta;
            for (int i = 0; i < 100; i++)
            {
                Vector3 pos = new Vector3(i / 20f, 0f, 0f);
                c = RandomColorGenerator.GetNextPseudoRandomColor(c); 
                Debug.Log(i + " = " + c);
                Debug.DrawRay(pos, Vector3.up, c);
            }
        }
    }
