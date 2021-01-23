    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    
    namespace Karaoke
    {
        public class ChordData
        {
            public ChordData(string chord, int position)
            {
                Chord = chord;
                Position = position;
            }
    
            #region Chord Property
            private String _chord;
            public String Chord
            {
                get { return _chord; }
                set { if (value != _chord) _chord = value; }
            }
            #endregion Chord Property
    
            #region Position Property
            private int _position;
            public int Position
            {
                get { return _position; }
                set { if (value != _position) _position = value; }
            }
            #endregion Position Property
        }
    
        public class KaraokeChar
        {
            public KaraokeChar(char txt)
            {
                Txt = txt;
                Chord = "";
            }
    
            #region Txt Property
            private Char _txt;
            public Char Txt
            {
                get { return _txt; }
                set { if (value != _txt) _txt = value; }
            }
            #endregion Txt Property
    
            #region Chord Property
            private String _chord;
            public String Chord
            {
                get { return _chord; }
                set { if (value != _chord) _chord = value; }
            }
            #endregion Chord Property
        }
    
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged([CallerMemberName] String propName = null)
            {
                // C#6.O
                // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    
        public class ItemViewModel : ViewModelBase
        {
            public ItemViewModel(string txt, List<ChordData> chordList)
            {
                foreach (char c in txt)
                {
                    Line.Add(new KaraokeChar(c));
                }
                foreach (ChordData chord in chordList)
                {
                    Line[chord.Position].Chord = chord.Chord;
                }
            }
    
            #region Line Property
            private ObservableCollection<KaraokeChar> _line = new ObservableCollection<KaraokeChar>();
            public ObservableCollection<KaraokeChar> Line
            {
                get { return _line; }
                set
                {
                    if (value != _line)
                    {
                        _line = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Line Property
        }
    
        public class MainViewModel : ViewModelBase
        {
            #region Song Property
            private ObservableCollection<ItemViewModel> _song = new ObservableCollection<ItemViewModel>();
            public ObservableCollection<ItemViewModel> Song
            {
                get { return _song; }
                set
                {
                    if (value != _song)
                    {
                        _song = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Song Property
    
            #region TextFont Property
            private int _textFont;
            public int TextFont
            {
                get { return _textFont; }
                set
                {
                    if (value != _textFont)
                    {
                        _textFont = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion TextFont Property
    
            #region ChordFont Property
            private int _chordFont;
            public int ChordFont
            {
                get { return _chordFont; }
                set
                {
                    if (value != _chordFont)
                    {
                        _chordFont = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion ChordFont Property
        }
    }
