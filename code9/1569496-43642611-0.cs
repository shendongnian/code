    StringBuilder builder = new StringBuilder();
    builder.AppendLine(string.Format("A Booking Form for Project #{0} - {1}",lblProjectID.Text, lblProjectName.Text));
    builder.AppendLine(string.Format(" - Release {0}  has been created or modified.", strReleaseName));
    builder.AppendLine();
    builder.AppendLine(Request.Url.ToString());
    String strBody = builder.ToString();
