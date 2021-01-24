    [assembly: Dependency(typeof(MediaHelper))]
    
    public class MediaHelper
    {
        public void ConvertToMp3(string fullFileName)
        {
            var infile = new MediaToolkit.Model.MediaFile { Filename = fullFileName;
            var outfile = new MediaToolkit.Model.MediaFile { Filename = $"{fullFileName}.mp3" };
            using (var engine = new MediaToolkit.Engine())
            {
                engine.GetMetadata(infile);
    
                engine.Convert(infile, outfile);
                if (File.Exists(fullFileName))
                {
                    File.Delete(fullFileName);
                }
            }
        }
    }
