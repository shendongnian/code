    static void Main( string[] args )
    {
        using ( var db = new DataContext() )
        {
            Room room_big = db.Rooms.FirstOrDefault( e => e.Name == "Big" );
            if ( room_big == null )
            {
                room_big = new Room
                {
                    Name = "Big",
                };
                db.Rooms.Add( room_big );
            }
            var agenda_1 = new Agenda
            {
                Owner = new AgendaRoom
                {
                    Room = room_big,
                    Information = "Some information",
                    RoomInformation = "Some information for the room",
                },
            };
            db.Agendas.Add( agenda_1 );
            db.SaveChanges();
            Trainer trainer_peter = db.Trainers.FirstOrDefault( e => e.Name == "Peter" );
            if ( trainer_peter == null )
            {
                trainer_peter = new Trainer
                {
                    Name = "Peter",                        
                };
                db.Trainers.Add( trainer_peter );
            }
            var agenda_2 = new Agenda
            {
                Owner = new AgendaTrainer
                {
                    Trainer = trainer_peter,
                    Information = "Some information",
                    TrainerInformation = "Some information for the trainer",
                },
            };
            db.Agendas.Add( agenda_2 );
            db.SaveChanges();
        }
    }
