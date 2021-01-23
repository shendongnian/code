    // In order to avoid int.MaxValue, long.MaxValue borders let's return strings 
    private static IEnumerable<string> FiveAndTwo() {
      Queue<string> agenda = new Queue<string>();
      agenda.Enqueue("2");
      agenda.Enqueue("5");
      while (true) {
        string value = agenda.Dequeue();
        yield return value;
        agenda.Enqueue(value + "2");
        agenda.Enqueue(value + "5");
      }
    }
