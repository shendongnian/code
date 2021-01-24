    public class PlayerPosition {
            public enum _verticalPosition { Top, Middle, Bottom };
            public enum _horizontalPosition { Left, Middle, Right };
    
            public PlayerPosition(char player, _verticalPosition vert, _horizontalPosition horiz) {
                if (player != 'x' && player != 'o') {
                    throw new ArgumentException("Player must be either x or o.");
                }
                Player = player;
                VerticalPosition = vert;
                HorizontalPositon = horiz;
            }
    
            public char Player { get; set; }
            public _verticalPosition VerticalPosition { get; set; }
            public _horizontalPosition HorizontalPositon { get; set; }
    
            public override bool Equals(object obj) {
                PlayerPosition pos = (PlayerPosition)obj;
                if (obj == null) {
                    return false;
                }
                else if (pos.HorizontalPositon == HorizontalPositon && pos.VerticalPosition == VerticalPosition
                        && pos.Player == Player) {
                    return true;
                }
    
                return false;
            }
    
            public override int GetHashCode() {
                return Player.GetHashCode() ^ HorizontalPositon.GetHashCode() ^ VerticalPosition.GetHashCode();
            }
    
            public static bool operator ==(PlayerPosition a, PlayerPosition b) {
                return Equals(a, b);
            }
    
            public static bool operator !=(PlayerPosition a, PlayerPosition b) {
                return !Equals(a, b);
    
            }
        }
