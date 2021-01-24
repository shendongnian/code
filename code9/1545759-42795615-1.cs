    public interface IPatientMapper {
        PatientViewModel GetViewModel(Patient patient, IDictionary<object, object> map = null);
    }
    public interface ICycleMapper {
        CycleViewModel GetViewModel(Cycle cycle, IDictionary<object, object> map = null);
    }
    public class CycleMapper : ICycleMapper
    {
        public IPatientMapper PatientMapper { get; set; }
        public CycleViewModel GetViewModel(Cycle cycle, IDictionary<object, object> map = null)
        {
            if (cycle == null) {
                return null;
            }
            // If called without map - create new one
            if (map == null)
                map = new Dictionary<object, object>();
            // if we already mapped this cycle before - don't do this again
            // and instead return already mapped entity
            if (map.ContainsKey(cycle))
                return (CycleViewModel)map[cycle];
            var viewModel = new CycleViewModel();
            viewModel.PatientId = cycle.PatientId;
            viewModel.CycleId = cycle.CycleId;
            viewModel.IsActive = cycle.IsActive;
            // add this entity to map before calling any other mappers
            map.Add(cycle, viewModel);
            // pass map to other mapper
            viewModel.Patient = PatientMapper.GetViewModel(cycle.Patient, map);
            return viewModel;
        }
    }
