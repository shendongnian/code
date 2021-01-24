    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverflow_LoopMadness
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ???
            }
            private static IEnumerable<ProductLineDto> GetGanttDataByPerson(IEnumerable<ProductLineDto> ganttData, GanttFilterDto ganttFilterDataModel)
            {
                if (ganttFilterDataModel.PersonId == null)
                    return ganttData;
                foreach (var pType in ganttData)
                {
                    foreach (var project in pType.Projects)
                    { 
                        project.Children = GetActivitiesForActivityPerson(project.Children, ganttFilterDataModel.PersonId);
                    }
                }
                return ganttData;
            }
            private static IEnumerable<SubProjectDto> GetActivitiesForActivityPerson(IEnumerable<SubProjectDto> children, Guid? personId)
            {
                foreach (var subProject in children)
                {
                    subProject.Activities = subProject.Activities.Where(a => a.ActivityPersons.All(person => person.PersonID != personId));
                    if (subProject.Children.Any())
                    {
                        GetActivitiesForActivityPerson(subProject.Children, personId);
                    }
                }
                return children;
            }
        }
        class SubProjectDto
        {
            public IEnumerable<Activity> Activities { get; internal set; }
            public IEnumerable<SubProjectDto> Children { get; internal set; }
        }
        class Activity
        {
            public IList<ActivityPerson> ActivityPersons { get; internal set; }
        }
        class ActivityPerson
        {
            public Guid? PersonID { get; internal set; }
        }
        class GanttFilterDto
        {
            public Guid PersonId { get; internal set; }
        }
        class ProductLineDto
        {
            public IList<Project> Projects { get; internal set; }
        }
        class Project
        {
            public IEnumerable<SubProjectDto> Children { get; set; }
        }
    }
