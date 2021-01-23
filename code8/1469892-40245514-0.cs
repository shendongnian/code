    public async Task DeleteProject(Project project)
    {
        var instance = UnitOfWork.Instance;
   
        await instance.SubProjectService.DeleteSubProjects(project.SubProjects);
        await instance.ProjectNoteService.DeleteProjectNotes(project.ProjectNotes);
        await instance.ProjectDocumentService.DeleteProjectDocuments(project.ProjectDocuments);
        await instance.ActivityService.DeleteActivities(project.Activities);
        await instance.ProjectPersonService.DeleteProjectPersons(project.ProjectPersons);          
    }
