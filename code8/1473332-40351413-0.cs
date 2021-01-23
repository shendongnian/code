    using System;
    using System.IO;
    
    public static class FileHelper {
    	public static int RemoveLines(string path, Predicate<string> remove) {
    		var removed = 0;
    		var lines = File.ReadAllLines(path);
    		using (var output = new StreamWriter(path)) {
    			foreach (var line in lines) {
    				if (remove(line)) {
    					removed++;
    				} else {
    					output.WriteLine(line);
    				}
    			}
    		}
    		return removed;
    	}
    }
