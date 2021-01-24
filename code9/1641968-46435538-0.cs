    public static IEnumerable<List<List<int>>> CreatePartitions(int[] seq, int k) {
      var n = seq.Length;
      var groups = new List<List<int>>(); 
      IEnumerable<List<List<int>>> generate_partitions(int i) {
        if (i >= n) {
          yield return new List<List<int>>(groups.Select(g => g.ToList()));
        }
        else {
          if (n - i > k - groups.Count)
            foreach (var group in new List<List<int>>(groups)) {
              group.Add(seq[i]);
              foreach (var d in generate_partitions(i + 1)) {
                yield return d;
              }
              group.RemoveAt(group.Count - 1);
            }
          if (groups.Count < k) {
            groups.Add(new List<int> {seq[i]});
            foreach (var d in generate_partitions(i + 1)) {
              yield return d;
            }
            groups.RemoveAt(groups.Count - 1);
          }
        }
      }
      return generate_partitions(0);
    }
