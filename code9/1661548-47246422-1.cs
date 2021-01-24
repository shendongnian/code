    		public void FindSentenceWithMaxOcc(){
            int index = 0;
            int maxSentenceIndex = 0;
            int maxCount = int.MinValue;
			
			//Iterate through dictionary containing words
            foreach(KeyValuePair<string, int> kv in dict){
				//Iterate through each sentence
				foreach(string element in list){
				
				//Split word by space
				string[] words = element.Split(' ');
				//Count number of occurances of word(key of dictionary) in sentence(from list)
				int temp = Array.indAll(words, s => s.Equals(kv.Key.Trim())).Length;
        
				//Store max occurance and index
				if(temp > maxCount){
                    maxCount = temp;
                    maxSentenceIndex = index;
                }
                index++;
            }
            index = 0;
        }
		//Print sentence
        Console.WriteLine(list[maxSentenceIndex]);
    }
