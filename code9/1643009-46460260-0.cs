        /// <summary>
        /// Shuffles the List.
        /// </summary>
        /// <typeparam name="T">Type in the list</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>Shuffled list</returns>
        public static List<T> Shuffle<T>(this List<T> list)
        {
            List<T> randomList = new List<T>();
            
            while (list.Any())
            {
                var randomIndex = rando.Next(0, list.Count());
                randomList.Add(list[randomIndex]); //add it to the new, random list
                list.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            return randomList; //return the new random list
        }
