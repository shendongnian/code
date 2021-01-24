    var arr = new int[] {1, 3, 4};
    var result = new List<string>();
    for (int i = 0 ; i < arr.Length ; i++) {
        for (int j = 0 ; j < arr.Length ; j++) {
            if (i != j) {
                result.Add($"{arr[i]} {arr[j]}");
            }
        }
    }
