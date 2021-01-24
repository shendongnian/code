    public class Dialogue
    {
        Dictionary<DialogSpecifier, string> specifiedDialog = new Dictionary<DialogSpecifier, string>();
        public Dialogue(string noneToNone)
        {
            specifiedDialog.Add(new DialogSpecifier(Gender.None, Gender.None), noneToNone);
        }
        public Dialogue Add(DialogSpecifier specifier, string dialogue)
        {
            specifiedDialog.Add(specifier, dialogue);
            return this;
        }
        public string OpeningGambit(Person speaker, Person listener)
        {
            string gambit;
            if (specifiedDialog.TryGetValue(new DialogSpecifier(speakerGender: speaker.Gender, listenerGender: listener.Gender),
                    out gambit))
                return gambit;
            return specifiedDialog[new DialogSpecifier(Gender.None, Gender.None)];
        }
    }
