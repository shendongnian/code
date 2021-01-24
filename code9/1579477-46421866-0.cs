        static Expression<Func<Project, bool>> CombineFilterExpression(
            Expression<Func<Project, bool>> firstProjectFilter, 
            Expression<Func<Project, bool>> secondProjectFilter,
            Expression<Func<SubProject, bool>> subProjectFilter
        )
        {
            //Create Project Parameter
            var param = Expression.Parameter(typeof(Project));
            //Create && Expression
            var body = Expression.AndAlso(
                Expression.Invoke(firstProjectFilter, param),
                Expression.AndAlso( //Create second && Expression
                    Expression.Invoke(secondProjectFilter, param),
                    //Pass SubProject instead of Project
                    Expression.Invoke(subProjectFilter, Expression.PropertyOrField(param, nameof(Project.SubProject)))
                )
            );
            //Make Lambda with Project parameter
            return Expression.Lambda<Func<Project, bool>>(body, param);
        }
