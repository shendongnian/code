    public static void SetGlobalBuildProperty( IServiceProvider package, string property, string value )
		{
			var projects = Microsoft.Build.Evaluation.ProjectCollection
				.GlobalProjectCollection
				.LoadedProjects;
			foreach ( var project in projects )
			{
				project.SetGlobalProperty( property, value );
				project.MarkDirty();
				project.ReevaluateIfNecessary();					
			}
			var dte = package.GetService( typeof( DTE ) ) as DTE2;
			var solution = dte.Solution as Solution2;
            var dteProjects = GetSolutionProjects( solution ) //Get all solution projects.
			foreach( var project in dteProjects )
			{
				var vsProject = project.Object as VSProject2;
				vsproject.Refresh();
			}			
		}
