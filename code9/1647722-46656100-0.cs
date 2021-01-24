    using System;
    using System.Collections.Generic;
    public class Class1
    {
        public void Example()
        {
            // a dictionary with string keys
            var string1 = "abcd";
            var string2 = "efgh";
            var dictionary1 = new Dictionary<string, int[]>
            {
                {string1, new[] {0, 1, 2}},
                {string2, new[] {3, 4, 5}}
            };
            // a dictionary with custom type
            var box1 = new Box(10, 10);
            var box2 = new Box(20, 20);
            var dictionary2 = new Dictionary<Box, int[]>
            {
                {box1, new[] {0, 1, 2}},
                {box2, new[] {3, 4, 5}}
            };
            // get random value from both dictionnaries
            var i1 = GetRandomInteger(dictionary1, string1);
            var i2 = GetRandomInteger(dictionary2, box1);
        }
        private int GetRandomInteger<TKey>(IDictionary<TKey, int[]> dictionary, TKey key)
        {
            if (!dictionary.ContainsKey(key))
                throw new KeyNotFoundException();
            var array = dictionary[key];
            // prefer UnityEngine.Random here since it's static 
            var index = new Random().Next(array.Length);
            var value = array[index];
            return value;
        }
    }
