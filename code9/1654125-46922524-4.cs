    public struct DialogSpecifier : IEquatable<DialogSpecifier>
    {
        public readonly Gender SpeakerGender;
        public readonly Gender ListenerGender;
        public DialogSpecifier(Gender speakerGender, Gender listenerGender)
        {
            SpeakerGender = speakerGender;
            ListenerGender = listenerGender;
        }
        public bool Equals(DialogSpecifier other)
        {
            return SpeakerGender==other.SpeakerGender
                && ListenerGender==other.ListenerGender;
        }
    }
