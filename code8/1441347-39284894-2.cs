    public class AnnotationMappingQueryBuilder {
        public void ConstructAddMappingQuery(IAnnotationMapping annotationMappings,
                                     out string commandText,
                                     out Dictionary<string, dynamic> parameters) {
            commandText = @"Insert Into AnnotationMapping Values 
                 (@AnnotationSetupId, @WordToAnnotate, 
                  @Annotation, @CreatedDttm, @CreatedUserId, @ModifiedDate, 
                  @ModifiedUserId, @IsActive)";
            parameters = new Dictionary<string, dynamic>();
            parameters.Add("@WordToAnnotate", annotationMappings.WordToAnnotate);
            parameters.Add("@Annotation", annotationMappings.Annotation);
            parameters.Add("@ModifiedDate", annotationMappings.ModifiedDate);
            parameters.Add("@ModifiedUserId", annotationMappings.ModifiedUserId);
            parameters.Add("@AnnotationSetupId", annotationMappings.AnnotationSetupId);
            parameters.Add("@CreatedDttm", annotationMappings.CreatedDttm);
            parameters.Add("@CreatedUserId", annotationMappings.CreatedUserId);
            parameters.Add("@IsActive", 1);
        }
    }
