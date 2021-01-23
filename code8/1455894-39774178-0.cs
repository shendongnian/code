    public class DicomManager
    {
        public List<Tag> ReadAllTags(string dicomFile)
        {
            var dcm = DICOMObject.Read(dicomFile);
            return dcm.AllElements.Select(e => e.Tag).ToList();
        }
    }
