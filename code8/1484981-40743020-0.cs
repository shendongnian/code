    db.Games.Add (new Game 
                         {
                             Date = Date, 
                             Home = HomeTeamId, // <-- Exception (string to Team class)
                             Visitor = VisitorTeamId, // <-- Property doesn't exists on Game class
                             HomeScore = HomeScore, // <--- Also not exists
                             VisitorScore = VisitorScore, // <--- missing
                             Park = ParkId, // <-- Exception (string to unknown class)
                             Attendance = Attendance // also not defined in your 'Game' Class
                         }
                     );
