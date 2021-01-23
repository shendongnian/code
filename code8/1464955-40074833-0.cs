    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "Testimonial";
            string word2 = "Tesla";
            string common = null;
            string difference1 = null;
            string difference2 = null;
            int index = 0;
            bool same = true;
            do
            {
                if (word1[index] == word2[index])
                {
                    common += word1[index];
                    ++index;
                }
                else
                {
                    same = false;
                }
            } while (same && index < word1.Length && index < word2.Length);
            for (int i = index; i < word1.Length; i++)
            {
                difference1 += word1[i];
            }
            for (int i = index; i < word2.Length; i++)
            {
                difference2 += word2[i];
            }
            Console.WriteLine(common);
            Console.WriteLine(difference1);
            Console.WriteLine(difference2);
            Console.ReadLine();
        }
    }
