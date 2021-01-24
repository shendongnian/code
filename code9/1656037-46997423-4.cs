    public class StudentDataAccess : IDataAccess<Student>
    {
        // initialized elsewhere in this class
        private MongoCollection<StudentDocument> _collection;
        public Task InsertAsync(Student entity)
        {
            var document = ConvertToDocument(entity);
            return _collection.InsertOneAsync(document); 
        }
        private StudentDocument ConvertToDocument(Student entity)
        { 
            // perform the conversion here....
        }
    }
