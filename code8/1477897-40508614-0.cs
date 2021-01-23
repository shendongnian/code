      abstract class Film {
        // let field be private, but property be protected 
        private string m_FilmName;
    
        public Film(string filmName) {
          FilmName = filmName;
        }
    
        public string FilmName {
          get {
            return m_FilmName;
          }
          protected set {
            // do not forget to validate the input value in public/protected methods
            if (string.IsNullOrWhiteSpace(value))
              throw new ArgumentNullException("value", 
                "FileName must not be null or white space");
    
            m_FilmName = value;
          }
        }
      }
    
...
    
      class Siries: Film {
        private int m_SeasonNumber;
    
        // Answer: 
        //   1. You have to call base class constructor ": base(filmName)"
        //   2. Add up some logic with "seasonNumber" - "SeasonNumber = seasonNumber;"
        public Siries(String filmName, int seasonNumber = 1)
          : base(filmName) {
    
          SeasonNumber = seasonNumber;
        }
    
        public int SeasonNumber {
          get {
            return m_SeasonNumber;
          } 
          protected set { // may be "private set" or just "set"
            // do not forget to validate the input value in public/protected methods
            if (value <= 0)
              throw new ArgumentOutOfRange("value", "SeasonNumber must be positive");
    
            m_SeasonNumber = value;
          }
        }
      } 
