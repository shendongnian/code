    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace BasketballScores
    {
    class BasketballPlayer
    {
        public class Entry
        {
            public int Value { get; set; }
            public string Name { get; set; }
        }
    public BasketballPlayer(string filename)
        {
            this.filename = filename;
        }
        private string filename;
        private List<Entry> data = new List<Entry>();
        public List<Entry> Data
        {
            get
            {
                // Clear data
                data.Clear();
                // Iterate through lines
                foreach (string line in System.IO.File.ReadLines(filename))
                {
                    // Split by space
                    List<string> parts = line.Trim().Split(' ').ToList();
                    if (parts.Count() < 2)
                        continue;
                    // Number is last space separated string
                    int number = int.Parse(parts.Last());
                    // Remove number
                    parts.RemoveAt(parts.Count() - 1);
                    // Name is any previous word joined by space
                    string name = string.Join(" ", parts).Trim();
                    // Add number and name to data
                    data.Add(new Entry() { Name = name, Value = number });
                }
                // Sort from greater value to smaller
                data.Sort(Comparer<Entry>.Create(
                    (l, r) => r.Value.CompareTo(l.Value)));
                return data;
            }
            set
            {
                using (var writer = new System.IO.StreamWriter(filename))
                {
                    foreach (var entry in value)
                    {
                        writer.WriteLine(string.Format("{0} {1}", entry.Name, entry.Value));
                    }
                }
                data = value;
            }
        }
        public double Average
        {
            get
            {
                // Read file if data is empty, otherwise reuse its value
                var src = (data.Count() == 0) ? Data : data;
                if (src.Count() == 0)
                    return 0.0;
                // Return average
                return src.Average(x => x.Value);
            }
        }
      }
    }
