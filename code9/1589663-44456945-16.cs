    Stopwatch sw = new Stopwatch();
    string path;
    int fileSize = 1024 * 1024 * 1024;
    int numFiles = 2;
    byte[] bytes = new byte[fileSize];
    Random r = new Random(DateTimeOffset.UtcNow.Millisecond);
    List<int> list = Enumerable.Range(0, numFiles).ToList();
    List<List<byte>> allBytes = new List<List<byte>>(numFiles);
    List<string> files;
    int numTests = 1;
    List<long> wss = new List<long>(numTests);
    List<long> wps = new List<long>(numTests);
    List<long> rss = new List<long>(numTests);
    List<long> rps = new List<long>(numTests);
    List<long> wsh = new List<long>(numTests);
    List<long> wph = new List<long>(numTests);
    List<long> rsh = new List<long>(numTests);
    List<long> rph = new List<long>(numTests);
    Enumerable.Range(1, numTests).ToList().ForEach((i) => {
        path = @"C:\SeqParTest\";
        allBytes.Clear();
        GC.Collect();
        GC.WaitForFullGCComplete();
        list.ForEach((x) => { r.NextBytes(bytes); allBytes.Add(new List<byte>(bytes)); });
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        list.AsParallel().ForAll((x) => File.WriteAllBytes(path + Path.GetRandomFileName(), allBytes[x].ToArray()));
        wps.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        Debug.Print($"Write parallel SSD #{i}: {wps[i - 1]}");
        allBytes.Clear();
        GC.Collect();
        GC.WaitForFullGCComplete();
        list.ForEach((x) => { r.NextBytes(bytes); allBytes.Add(new List<byte>(bytes)); });
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        list.ForEach((x) => File.WriteAllBytes(path + Path.GetRandomFileName(), allBytes[x].ToArray()));
        wss.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        Debug.Print($"Write serial   SSD #{i}: {wss[i - 1]}");
        files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Take(numFiles).ToList();
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        files.AsParallel().ForAll(f => File.ReadAllBytes(f).GetHashCode());
        rps.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        files.ForEach(f => File.Delete(f));
        Debug.Print($"Read  parallel SSD #{i}: {rps[i - 1]}");
        GC.Collect();
        GC.WaitForFullGCComplete();
        files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Take(numFiles).ToList();
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        files.ForEach(f => File.ReadAllBytes(f).GetHashCode());
        rss.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        files.ForEach(f => File.Delete(f));
        Debug.Print($"Read  serial   SSD #{i}: {rss[i - 1]}");
        GC.Collect();
        GC.WaitForFullGCComplete();
        path = @"C:\SeqParTest\";
        allBytes.Clear();
        GC.Collect();
        GC.WaitForFullGCComplete();
        list.ForEach((x) => { r.NextBytes(bytes); allBytes.Add(new List<byte>(bytes)); });
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        list.AsParallel().ForAll((x) => File.WriteAllBytes(path + Path.GetRandomFileName(), allBytes[x].ToArray()));
        wph.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        Debug.Print($"Write parallel HDD #{i}: {wph[i - 1]}");
        allBytes.Clear();
        GC.Collect();
        GC.WaitForFullGCComplete();
        list.ForEach((x) => { r.NextBytes(bytes); allBytes.Add(new List<byte>(bytes)); });
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        list.ForEach((x) => File.WriteAllBytes(path + Path.GetRandomFileName(), allBytes[x].ToArray()));
        wsh.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        Debug.Print($"Write serial   HDD #{i}: {wsh[i - 1]}");
        files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Take(numFiles).ToList();
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        files.AsParallel().ForAll(f => File.ReadAllBytes(f).GetHashCode());
        rph.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        files.ForEach(f => File.Delete(f));
        Debug.Print($"Read  parallel HDD #{i}: {rph[i - 1]}");
        GC.Collect();
        GC.WaitForFullGCComplete();
        files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Take(numFiles).ToList();
        try { GC.TryStartNoGCRegion(0, true); } catch (Exception) { }
        sw.Restart();
        files.ForEach(f => File.ReadAllBytes(f).GetHashCode());
        rsh.Add(sw.ElapsedMilliseconds);
        sw.Stop();
        try { GC.EndNoGCRegion(); } catch (Exception) { }
        files.ForEach(f => File.Delete(f));
        Debug.Print($"Read  serial   HDD #{i}: {rsh[i - 1]}");
        GC.Collect();
        GC.WaitForFullGCComplete();
    });
    Debug.Print($"Avg Write Parallel SSD: {wps.Average()}");
    Debug.Print($"Avg Write Serial   SSD: {wss.Average()}");
    Debug.Print($"Avg Read  Parallel SSD: {rps.Average()}");
    Debug.Print($"Avg Read  Serial   SSD: {rss.Average()}");
    Debug.Print($"Avg Write Parallel HDD: {wph.Average()}");
    Debug.Print($"Avg Write Serial   HDD: {wsh.Average()}");
    Debug.Print($"Avg Read  Parallel HDD: {rph.Average()}");
    Debug.Print($"Avg Read  Serial   HDD: {rsh.Average()}");
