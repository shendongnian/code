        var result=CCEScholasticTests.join(db2.CCESubjectSkills ,o=>o.CCESubjectSkillID, od=>od.CCESubjectSkillID,(o, od)=> new 
        {
        				   BranchSectionID = o.BranchSectionID,
                                           CCEScholasticTestID = o.CCEScholasticTestID,
                                           CCEScholasticTestName = o.CCEScholasticTestName,
                                           CCESubjectSkillID = o.CCESubjectSkillID,
                                           CCEvaluationID = o.CCEvaluationID,
                                           MaxMarks = o.MaxMarks,
                                           SubjectID = o.SubjectID,
                                           TestDate = o.TestDate,
                                           MarksEntryLastDate = o.MarksEntryLastDate,
    CCEScholasticSkillMasterID = od.CCEScholasticSkillMasterID
        }).join(db2.CCEScholasticSkillsMasters, s=>s.CCEScholasticSkillMasterID = t.CCEScholasticSkillMasterID, t=>t.CCEScholasticSkillMasterID,(s,t)=> new
        {
          				   BranchSectionID = o.BranchSectionID,
                                           CCEScholasticTestID = o.CCEScholasticTestID,
                                           CCEScholasticTestName = o.CCEScholasticTestName,
                                           CCESubjectSkillID = o.CCESubjectSkillID,
                                           CCEvaluationID = o.CCEvaluationID,
                                           MaxMarks = o.MaxMarks,
                                           SubjectID = o.SubjectID,
                                           TestDate = o.TestDate,
                                           MarksEntryLastDate = o.MarksEntryLastDate,
        				   CCESubjectSkillName = t.CCESubjectSkillName,
        				   CCEScholasticSkillMasterID = t.CCEScholasticSkillMasterID,
                                           CCEScholasticSkillName = t.CCEScholasticSkillName
        }).tolist();
