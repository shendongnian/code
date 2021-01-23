    public interface IField {
        Style style {get;set}
        /* Your property */
    }
    public class Label {
        Style style {get;set}
        IField field {get;set}
        /* Your property */
    }
