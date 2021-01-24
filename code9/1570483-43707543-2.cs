    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace blah
    {
        //there could be a problem with VERY large files and running out of ram. if we end up having those,
        //switch to reading the resource stream and
        //appending the bytes to the file, instead of reading in full and writing in full.
        //-DOSLuke
    
        //instructions:
    
        //to add a resource:
        //add it like usual in the solution explorer
        //right click the newly added resource and click properties
        //under the 'build action' dropdown, select 'embedded resource'
        //then it is ready to be accessed.
    
    
        //to get a location on disk of a resource: ---this is what our program uses the most.
        //use ResourceHelper.GetResourceLocation("filename.extension");
        //for example:
        //ResourceHelper.GetResourceLocation("template.txt");
    
    
        //to obtain a raw resource stream for manipulation
        //ResourceHelper.GetResourceStream("template.txt");
        //this is the proper way of accessing resources
    
    
        //to get all the bytes from a resource via a resource stream:
        //ResourceHelper.ReadStreamFully(ResourceHelper.GetResourceStream("template.txt"));
    
    
        //what GetResourceLocation(string filename) is doing behind the scenes:
        //it starts by doing some possible cleaning of temp folder and some checking to make sure
        //the requested resource exists.
        //it gets or is given a resource stream (the proper way of accessing resources)
        //it gets all the bytes from the stream.
        //it saves all bytes into a file with the given filename that you are trying to access
        //it then returns the location of that temp file for you to use.
        //please note, that the file name doesnt matter, as long as the bytes in the file are exactly the same as the original resource file / embedded resource.
        //so basically it just copies the resource to a known location on disk and returns the location.
    
        class ResourceHelper
        {
            private static bool HasBeenCleanedOnce = false;
            private static object LockHolder = new object();
    
            public static string temppath = "temp_path_on_disk";
    
            public static string GetResourceLocation(string filename)
            {
                return GetResourceLocation(filename, GetResourceStream(filename));
            }
    
            public static string GetResourceLocation(string filename, Stream resourcestream)
            {
                lock (LockHolder) //this safely protects resources so only one thread (that locks with the locker object) can access the resource at a time
                {
                    string place = temppath + filename;
    
                    Directory.CreateDirectory(temppath);
    
                    //it will only clean once close to the start of every program start
                    if (!HasBeenCleanedOnce)
                    {
                        foreach (string file in Directory.GetFiles(temppath))
                            File.Delete(file);
                        
                        HasBeenCleanedOnce = true;
                    }
    
                    if (!File.Exists(place))
                        File.WriteAllBytes(place, ReadStreamFully(resourcestream));
    
                    return place;
                }
            }
    
            //gets a resource and returns a stream that can read it
            public static Stream GetResourceStream(string file)
            {
                string resourceName = "your_solution_name.Resources." + file;
    
                string[] resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                
                if (!resources.Contains(resourceName))
                {
                    MessageBox.Show("Resource '" + file + "' could not be found at '" + resourceName 
                        + "'. Did you add the resource and set the resource to be embedded?" 
                        + Environment.NewLine + Environment.NewLine + "This will likely break after clicking 'ok'", "ERROR");
                }
    
                return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            }
    
            //reads a stream fully and returns a byte[] array of the contents
            public static byte[] ReadStreamFully(Stream input)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    input.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
