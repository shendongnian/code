    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace analyzeduplicates {
      public interface IFileAnalyzer {
        IStringToDirectoryHelper StringToDirectoryHelper { set; }
        ISetFileHelper SetFileLoader { set; }
        void Analyze( string targetFile, string targetDirectory );
      }
      public interface IStringToDirectoryHelper {
        string[] GetPathFromString( string value );
      }
      public class StringToDirectoryHelper : IStringToDirectoryHelper {
        public string[] GetPathFromString( string value ) {
          string item = value.Trim();
          return item
            .Trim()
            .Split( new[] { "\\", "/", ":", "@", "%", ":", "?", "&", ";", "." }, StringSplitOptions.RemoveEmptyEntries )
            .Take( 3 )
            .Concat(new string[] { item.Length.ToString(), item[0].ToString() + item[value.Length-1].ToString() } )
            .ToArray();
        }
      }
      public interface ISetFileHelper {
        IReadOnlyCollection<string> GetSetFromFile( string path );
        void AddToSetFile( string path, string value );
      }
      public class SetFileHelper : ISetFileHelper {
        public IReadOnlyCollection<string> GetSetFromFile( string path ) {
          if (!Directory.Exists(Path.GetDirectoryName(path))) {
            return new List<string>();
          }
          if (!File.Exists(path)) {
            return new List<string>();
          }
          return File.ReadAllLines( path );
        }
        public void AddToSetFile( string path, string value) {
          if (!Directory.Exists(Path.GetDirectoryName(path))) {
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
          }
          File.AppendAllLines( path, new string[] { value } );
        }
      }
      public class FileAnalyzer: IFileAnalyzer {
        public IStringToDirectoryHelper StringToDirectoryHelper { get; set; }
        public ISetFileHelper SetFileLoader { get; set; }
        public FileAnalyzer() {
        }
        public FileAnalyzer(
          IStringToDirectoryHelper stringToDirectoryHelper, 
          ISetFileHelper setFileLoader) : this() {
          StringToDirectoryHelper = stringToDirectoryHelper;
          SetFileLoader = setFileLoader;
        }
        private void EnsureParametersSet() {
          if (StringToDirectoryHelper == null) {
            throw new InvalidOperationException( $"Cannot start analyzing without {nameof(StringToDirectoryHelper)}" );
          }
          if (SetFileLoader == null) {
            throw new InvalidOperationException( $"Cannot start analyzing without {nameof( SetFileLoader )}" );
          }
        }
        public void Analyze( string targetFile, string targetDirectory ) {
          EnsureParametersSet();
          using (var reader = new StreamReader(targetFile, true)) {
            long count = 0;
            while (!reader.EndOfStream) {
              if (count % 1000 == 0) {
                Console.WriteLine( $"Analyzing line {count}-{count + 1000}" );
              }
              count++;
              string line = reader.ReadLine();
              if (string.IsNullOrWhiteSpace(line)) {
                // nothing meaningfull can be done
                continue;
              }
              var path = StringToDirectoryHelper.GetPathFromString( line );
              string targetPath = Path.Combine( new[] { targetDirectory }.Concat( path ).ToArray() );
              var set = SetFileLoader.GetSetFromFile( targetPath );
              if (set.Contains(line)) {
                // duplicate, don't care for it
                continue;
              }
              SetFileLoader.AddToSetFile( targetPath, line );
            }
          }
        }
      }
    }
