    foreach (var @class in classes)
    {
        foreach (var pupil in @class.Pupils)
        {
            pupil.GradutaionYear = @class.GraduationYear;
        }
                   
        await _classRepository.AddClass(@class);
    }
    await _classRepository.SaveChanges();
