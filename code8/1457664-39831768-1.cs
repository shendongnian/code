    var data = new float[] {1, 2, 3, 4, 5, 6};
    var indexToWeight = (index) => {
      if (index == 3) return 2;
      return 1; 
    };
    var total = data.Select((value, index) => indexToWeight(index)).Sum(); 
    var weightedData = data.Select((value, index) => Tuple.Create(value, indexToWeight(index)/(float)sum)).ToList();
    var boundedData = new List<Tuple<float, float>>(weightedData.Count);
    float bound = 0.0f;
    for (int i = 0; i < weightedData.Count; i++) {
      boundedData.Add(Tuple.Create(weightedData[i].Item1, bound));
      bound += weightedData[i].Item2;
    }
    var weightedToValue = (List<Tuple<float, float>> wv, float p) => {
      var pair = wv.FirstOrDefault(item => item.Item2 > p);
      if (pair != null) return pair.Item1;
      return vw.Last().Item1; 
    }; 
    Random random;
    var randomizedData = Enumerable.Range(1, data.Count).Select(index => weightedtoValue(weightedData, random.NextDouble())).ToArray();   
