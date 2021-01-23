    public class NaturalSortComparer : System.Collections.IComparer {
        private System.Collections.Generic.Dictionary<string, string[]> table;
        public NaturalSortComparer() {
            table = new System.Collections.Generic.Dictionary<string, string[]>();
        }
        public void Dispose() {
            table.Clear();
            table = null;
        }
        public int Compare(object x, object y) {
            System.Windows.Forms.DataGridViewRow DataGridViewRow1 = (System.Windows.Forms.DataGridViewRow)x;
            System.Windows.Forms.DataGridViewRow DataGridViewRow2 = (System.Windows.Forms.DataGridViewRow)y;
            string xStr = DataGridViewRow1.Cells["Column1"].Value.ToString();
            string yStr = DataGridViewRow2.Cells["Column1"].Value.ToString();
            if (xStr == yStr) {
                return 0;
            }
            string[] x1, y1;
            if (!table.TryGetValue(xStr, out x1)) {
                x1 = System.Text.RegularExpressions.Regex.Split(xStr.Replace(" ", ""), "([0-9]+)");
                table.Add(xStr, x1);
            }
            if (!table.TryGetValue(yStr, out y1)) {
                y1 = System.Text.RegularExpressions.Regex.Split(yStr.Replace(" ", ""), "([0-9]+)");
                table.Add(yStr, y1);
            }
            for (int i = 0; i < x1.Length && i < y1.Length; i++) {
                if (x1[i] != y1[i]) {
                    return PartCompare(x1[i], y1[i]);
                }
            }
            if (y1.Length > x1.Length) {
                return 1;
            } else if (x1.Length > y1.Length) {
                return -1;
            } else {
                return 0;
            }
        }
        private static int PartCompare(string left, string right) {
            int x, y;
            if (!int.TryParse(left, out x)) {
                return left.CompareTo(right);
            }
            if (!int.TryParse(right, out y)) {
                return left.CompareTo(right);
            }
            return x.CompareTo(y);
        }
    }
