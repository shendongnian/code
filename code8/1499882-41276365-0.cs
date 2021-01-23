        public static void GetInputs()
        {
            string[] scores_temp = data.Split(' ');
            var distinctScores = scores_temp.Distinct().ToArray();
            int[] scores = (Array.ConvertAll(distinctScores, Int32.Parse)).Reverse().ToArray();
            string[] alice_temp = data2.Split(' ');
            int[] aliceScores = Array.ConvertAll(alice_temp, Int32.Parse);
            int rank = 0;
            for (int i = 0, j = 0; i < aliceScores.Length && j < scores.Length; ++i)
            {
                while (aliceScores[i] > scores[j])
                    rank = j++;
                Console.WriteLine(String.Format("Rank {0}: alice {1} -- Index {2}: score {3}", rank, aliceScores[i], j, scores[j]));
            }
            Console.ReadLine();
        }
