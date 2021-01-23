    public interface ISerializerStrategy<T>
    {
        XDocument Serialize(T presetDataDto);
        T Deserialize(XDocument xDocument);
    }
    
    public class PatientDtoSerializerStrategy : ISerializerStrategy<PatientDto>
    {
        XDocument Serialize(PatientDto presetDataDto);
        PatientDto Deserialize(XDocument xDocument);
    }
    
    public class PrescriberDtoSerializerStrategy : ISerializerStrategy<PrescriberDto>
    {
        XDocument Serialize(PrescriberDto presetDataDto);
        PrescriberDto Deserialize(XDocument xDocument);
    }
