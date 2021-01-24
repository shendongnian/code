    public class HotelRoom_Search : AbstractIndexCreationTask<HotelRoom>
    {
        public HotelRoom_Search()
        {
            Map = rooms => from room in rooms
                           select new
                           {
                               //bla bla
                               room.DndUntilUtc // add this line
                               //bla bla
                           };
            Indexes.Add(x => x.DndUntilUtc, FieldIndexing.Analyzed);
           
        }
    }
