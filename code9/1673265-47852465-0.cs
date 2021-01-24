    public static class Program
    {
        public static void Main(string[] args)
        {
            var gathering = new Gathering();
            gathering.MakeSelections();
            foreach (var item in gathering.participants)
            {
                Console.WriteLine(item.name + ":" + item.selectedParticipant);
            }
        }
        public class Participant
        {
            public string name;
            public List<string> exclusions;
            public string selectedParticipant;
        }
        public class Gathering
        {
            public List<Participant> participants;
            public List<string> availableParticipants;
            public List<string> usedNames;
            public Dictionary<string, string> result;
            public Gathering()
            {
                //initialize participants
                participants = new List<Participant>();
                participants.Add(new Participant
                {
                    name = "James",
                    exclusions = new List<string> { "Tiffany", "Tyrone" }
                });
                participants.Add(new Participant
                {
                    name = "John",
                    exclusions = new List<string> { }
                });
                participants.Add(new Participant
                {
                    name = "Judith",
                    exclusions = new List<string> { }
                });
                participants.Add(new Participant
                {
                    name = "Rebecca",
                    exclusions = new List<string> { "James", "Tiffany" }
                });
                participants.Add(new Participant
                {
                    name = "Tiffany",
                    exclusions = new List<string> { }
                });
                participants.Add(new Participant
                {
                    name = "Tyrone",
                    exclusions = new List<string> { }
                });
                //prevent participants from selecting themselves
                foreach (Participant p in participants)
                {
                    p.exclusions.Add(p.name);
                }
                //create list of all the names (all available participants at the beginning)
                availableParticipants = participants.Select(x => x.name).ToList();
            }
            public void MakeSelections()
            {
                Participant currentParticipant;
                Random randy = new Random();
                //Sort Participants by the length of their exclusion lists, in descending order.
                participants.Sort((p1, p2) => p2.exclusions.Count.CompareTo(p1.exclusions.Count));
                //Get the first participant in the list which hasn't selected someone yet
                currentParticipant = participants.FirstOrDefault(p => p.selectedParticipant == null);
                while (currentParticipant != null)
                {
                    //of the available participants, create a list to choose from for the current participant
                    List<string> listToChooseFrom = availableParticipants.Where(x => !currentParticipant.exclusions.Contains(x)).ToList();
                    //select a random participant from the list of eligible ones to be matched with the current participant
                    string assignee = listToChooseFrom[randy.Next(listToChooseFrom.Count)];
                    currentParticipant.selectedParticipant = assignee;
                    //remove the selected participant from the list of available participants
                    availableParticipants.RemoveAt(availableParticipants.IndexOf(assignee));
                    //remove the selected participant from everyone's exclusion lists
                    foreach (Participant p in participants)
                        if (p.exclusions.Contains(assignee))
                            p.exclusions.RemoveAt(p.exclusions.IndexOf(assignee));
                    //Resort Participants by the length of their exclusion lists, in descending order.
                    participants.Sort((p1, p2) => p2.exclusions.Count.CompareTo(p1.exclusions.Count));
                    //Get the first participant in the list which hasn't selected someone yet
                    currentParticipant = participants.FirstOrDefault(p => p.selectedParticipant == null);
                }
                //finally, sort by alphabetical order
                participants.Sort((p1, p2) => p1.name.CompareTo(p2.name));
            }
        }
    }
