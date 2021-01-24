            String inputSample = "46764833";
            var chars = inputSample.ToCharArray().Select(c => c.ToString()).ToArray();
            int[] intLoyaltyNumber2 = Array.ConvertAll(chars, int.Parse);
            for (int ctr = 0; ctr < chars.Length; ctr++)
                Console.WriteLine("{0}: {1}", ctr, chars[ctr]);
