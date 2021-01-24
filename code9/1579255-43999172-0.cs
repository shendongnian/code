    await _model.LoadAsync();
    SubjectsToChooseFrom = new ObservableCollection<SubjectDTO>(_model.Subjects);
    ObservableCollection<SubjectDTO> temp = new ObservableCollection<SubjectDTO>();
    foreach (var subject in SubjectsToChooseFrom) {
        if(subject.ProgId == CurrentProgId)
        {
            temp.Add(subject);
        }
    }
    SubjectsToChooseFrom = temp;
