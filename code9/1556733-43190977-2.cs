	class TailQueue<T> {
		readonly T[] Buffer;
		bool Full = false;
		int Head = -1;
		public TailQueue(int quesize) {
			Buffer = new T[quesize];
		}
		public void Enqueue(T elem) {
			Head = Head == Buffer.Length - 1 ? 0 : Head + 1;
			Buffer[Head] = elem;
			if (Head == Buffer.Length - 1)
				Full = true;
		}
		public IEnumerable<T> GetAll() {
			if (Head == -1)
				yield break;
			var startIndex = 0;
			if (Full && Head != Buffer.Length - 1)
				startIndex = Head + 1;
			for (int i = startIndex; i <= Head; i = (i + 1) % Buffer.Length) {
				yield return Buffer[i];
			}
		}
	}
	static IEnumerable<string> GrepTail(string filePath, string expression, int lineCount) {
		var lineQ = new TailQueue<string>(lineCount);
		foreach (var line in File.ReadLines(filePath)) {
			if (line.IndexOf(expression, StringComparison.OrdinalIgnoreCase) != -1)
				lineQ.Enqueue(line);
		}
		return lineQ.GetAll();
	}
