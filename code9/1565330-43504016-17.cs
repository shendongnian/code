    public class FileData
    {
        public int File1Value { get; set; }
        public decimal File2Value { get; set; }
        /// <summary>
        /// Provides a friendly string representation of this object
        /// </summary>
        /// <returns>A string showing the File1 and File2 values</returns>
        public override string ToString()
        {
            return $"{File1Value}: {File2Value}";
        }
    }
