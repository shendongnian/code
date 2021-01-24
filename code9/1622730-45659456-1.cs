        public abstract class DataWriterAbstract
        {
            public abstract void WriteData(float dataToWrite);
        }
        public class DataWriter : DataWriterAbstract
        {
            public override void WriteData(float dataToWrite)
            {
                // some writing magic
                Console.WriteLine(dataToWrite);
            }
        }
