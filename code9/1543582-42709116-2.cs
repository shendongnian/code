    <tbody>
      <tr>
          <td>
                @:<script>
                {
                 var assessmentIndex = getPosition(@geResult.assessmentId);
                 var studentIndex = getPosition(@geResult.StudentID);
                 @geResult.ResultValue
                 }
                 </script>
                 @foreach(Assessment geAssessment in Model.assessments)
                 {
                                                
                 }
            </td>
      </tr>
     </tbody>
