    private string GetSlideDuration(SlidePart slidePart)
        {
            string returnDuration = "0";
            try
            {
                Slide slide1 = slidePart.Slide;
                var transitions = slide1.Descendants<Transition>(); 
                foreach (var transition in transitions)
                {
                    if (transition.AdvanceAfterTime.HasValue)
                        return transition.AdvanceAfterTime;
                    break;
                }
            }
            catch (Exception ex)
            {
                //Do nothing
            }
            return returnDuration;
        }
