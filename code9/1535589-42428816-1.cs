    int c = 123; var L = Enumerable.Range(0, c).ToList();
    GC.Collect(); var sw1 = Stopwatch.StartNew(); L.Cast<object>().ToList(); sw1.Stop();
    GC.Collect(); var sw2 = Stopwatch.StartNew(); L.ConvertAll(i => (object)i); sw2.Stop();
    MessageBox.Show($"Cast.ToList\t{sw1.Elapsed}\t{(double)sw1.ElapsedTicks / sw2.ElapsedTicks}\n" +
                    $"ConvertAll \t{sw2.Elapsed}\t{(double)sw2.ElapsedTicks / sw1.ElapsedTicks}");
