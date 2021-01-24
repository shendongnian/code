        static IObservable<IWizardStep<T>> Walk<T>(IWizardStep<T> step)
        {
            if (step?.NextStepChoice == null)
                return Observable.Return(step);
            return step.NextStepChoice.SelectMany(choice => Walk(choice.Step)).StartWith(step);
        }
