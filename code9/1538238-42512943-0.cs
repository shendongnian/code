    private void ViewButtonClicked(object sender, ReportParametersEventArgs e)
            {
                var SubmittedParameters = e.Parameters.Clone();
                e.Parameters.Clear();
                SubmittedParameters.Where(x => x.Name == "Parametername").FirstOrDefault().Values[0] = "YourValue";
                SubmittedParameters.ToList().ForEach(x => e.Parameters.Add(x));
            }
            private void OnReportChosenFromList()
            {
                reportViewer.SubmittingParameterValues -= ViewButtonClicked;
                reportViewer.SubmittingParameterValues += ViewButtonClicked;
            }
