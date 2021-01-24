    using System;
    using System.Diagnostics;
    using System.IO;
    namespace analyzeduplicates {
      class Program {
        static void Main( string[] args ) {
          string targetFile = Path.Combine( Environment.CurrentDirectory, "source.txt" );
          if (File.Exists(targetFile)) {
            File.Delete( targetFile );
          }
          if ( !File.Exists( targetFile ) ) {
            Console.WriteLine( "Generating extensive list of urls" );
            Stopwatch generateWatch = Stopwatch.StartNew();
            GenerateList( targetFile );
            generateWatch.Stop();
            Console.WriteLine( "Generating took {0:hh\\:mm\\:ss}", generateWatch.Elapsed );
          }
          Console.WriteLine( "Analyzing file" );
          Stopwatch analyzeWatch = Stopwatch.StartNew();
          IFileAnalyzer analyzer = new FileAnalyzer(new StringToDirectoryHelper(), new SetFileHelper());
          analyzer.Analyze( targetFile, Environment.CurrentDirectory );
          analyzeWatch.Stop();
          Console.WriteLine( "Analyzing took {0:hh\\:mm\\:ss}", analyzeWatch.Elapsed );
          Console.WriteLine( "done, press enter to clean up" );
          Console.ReadLine();
          File.Delete( targetFile );
          foreach (var dir in Directory.GetDirectories( Environment.CurrentDirectory )) {
            Directory.Delete( dir, true );
          }
          Console.WriteLine( "Cleanup completed, press enter to exit" );
          Console.ReadLine();
        }
        public static void GenerateList( string targetFile ) {
          string[] domains = new[] {
            "www.google.com",
            "www.google.de",
            "www.google.ca",
            "www.google.uk",
            "www.google.co.uk",
            "www.google.nl",
            "www.google.be",
            "www.google.fr",
            "www.google.sa",
            "www.google.me",
            "www.youtube.com",
            "www.youtube.de",
            "www.youtube.ca",
            "www.youtube.uk",
            "www.youtube.co.uk",
            "www.youtube.nl",
            "www.youtube.be",
            "www.youtube.fr",
            "www.youtube.sa",
            "www.youtube.me"
          };
          string[] paths = new[] {
            "search","indicate", "test", "generate", "bla", "bolognes", "macaroni", "part", "of", "web", "site", "index", "main", "nav"
          };
          string[] extensions = new[] {
            "", ".html", ".php", ".aspx", ".aspx", "htm"
          };
          string[] query = new[] {
            "", "?s=test", "?s=query&b=boloni", "?isgreat", "#home", "#main", "#nav"
          };
          string[] protocols = new[] {
            "http://", "https://", "ftp://", "ftps://"
          };
          using (var writer = new StreamWriter(targetFile)) {
            var rnd = new Random();
            for (long i = 0; i < 1000000; i++) {
              int pathLength = rnd.Next( 5 );
              string path = "/";
              if (pathLength > 0) {
                for (int j = 0; j< pathLength; j++ ) {
                  path += paths[rnd.Next( paths.Length )] + "/";
                }
              }
              writer.WriteLine( "{0}{1}{2}{3}{4}{5}", protocols[rnd.Next( protocols.Length )], domains[rnd.Next(domains.Length)], path, paths[rnd.Next(paths.Length)], extensions[rnd.Next(extensions.Length)], query[rnd.Next(query.Length)] );
            }
          }
        }
      }
    }
