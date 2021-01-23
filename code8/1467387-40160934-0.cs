            string field = "{ apples, pears, bananas, grapes }";
            string input = "apple Banana Pears";
            List<string> result = null; 
            string[] inputs = input.ToLower().Split(' ');           
            foreach (var item in inputs)
            {
                if (field.ToLower().Contains(item)) result.Add(item);               
            }
            return result;
            //This will match even if input word is a substring in the field , which may not be a complete word in field.
            //e.g. banana is found in bananas in field. is it fine.
