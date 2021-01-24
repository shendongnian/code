        [Export]
        public class TocViewModel : IClosingValidator
        {
            [ImportingConstructor]
            public TocViewModel(MeasurementSequenceExecution measurementSequenceExecution)
            {
                this.measurementSequenceExecution = measurementSequenceExecution;
            }
        
                public Boolean CanApplicationClose
            {
                get { return !this.measurementSequenceExecution.IsMeasurementSequenceRunning; }
                set
                {
                    this.measurementSequenceExecution.IsMeasurementSequenceRunning = !value;
                }
            }
