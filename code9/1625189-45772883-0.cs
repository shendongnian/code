    using System.IO;
    using System.Diagnostics;
    
    ...
    using (StreamReader str = new StreamReader(@"C:\test.txt"))
    {
	    string holder;
	    Stopwatch sw = new Stopwatch();
	    sw.Start();
	    while ((holder = str.ReadLine()) != null)
	    {
		    if (holder.Contains("some piece of text that I'm looking for"))
		    {
			    //do something
			    break;
		    }                    
		    if (sw.ElapsedMilliseconds > 3000) { break; }
	    }
	    sw.Stop();
	    str.Close();
    }
