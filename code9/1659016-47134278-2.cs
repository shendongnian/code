    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Reflection;
    
    public class AutoFill : MonoBehaviour
    {
        public float mscore = 5 ;
        public float hscore = 10 ;
    
        public InputField inputField;
        public RectTransform tagsParent;
        public RectTransform tagPrefab;
    
        private List<FieldInfo> fields ;
        private Regex regex = new Regex( "@[a-zA-Z0-9]+$" );
    
        /// <summary>
        /// Awake is called when the script instance is being loaded
        /// </summary>
        private void Awake()
        {
            fields = GetType().GetFields( BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public )
                            .Where( fieldInfo => fieldInfo.FieldType == typeof( float ) ) // Use this if you want to retrieve only the floating variables
                            .ToList();
    
            inputField.onValueChanged.AddListener( OnInputValueChanged );
        }
    
        /// <summary>
        /// Called when the value of the input has changed
        /// </summary>
        /// <param name="input"></param>
        private void OnInputValueChanged( string input )
        {
            Match match = regex.Match( inputField.text );
            if ( match.Success )
            {
                string value = match.Value.Substring(1);
                List<string> tags = GetTagsStartingWith( value );
    
                FillTagsSuggestions( match.Value, tags );
            }
            else
            {
                FillTagsSuggestions( string.Empty, new List<string>() );
            }
        }
    
        /// <summary>
        /// Fill the tags suggestion
        /// </summary>
        /// <param name="tagInput"></param>
        /// <param name="tags"></param>
        private void FillTagsSuggestions( string tagInput, List<string> tags )
        {
            int length = Mathf.Max( tags.Count, tagsParent.childCount );
    
            for ( int index = 0 ; index < length ; index++ )
            {
                int i = index; // Used to prevent closure problem
                if ( index < tags.Count )
                {
                    AddTagSuggestion( tags[index], index, tagInput );
                }
                else if( index < tagsParent.childCount )
                {
                    tagsParent.GetChild( index ).gameObject.SetActive( false );
                }
            }
        }
    
        /// <summary>
        /// Adds a tag suggestion
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="tagInput"></param>
        private void AddTagSuggestion( string tag, int index, string tagInput )
        {
            Text text;
            RectTransform suggestionTransform;
    
            // Get existing button if exists
            if ( index < tagsParent.childCount )
            {
                suggestionTransform = tagsParent.GetChild( index ) as RectTransform;
                suggestionTransform.gameObject.SetActive( true );
                text = suggestionTransform.GetComponentInChildren<Text>();
            }
            // Create new button if does not exist yet
            else
            {
                suggestionTransform = Instantiate( tagPrefab );
                text = suggestionTransform.GetComponentInChildren<Text>();
                suggestionTransform.SetParent( tagsParent, true );
            }
    
            text.text = tag;
    
            // Add listener to replace the input by the value of the tag
            Button btn = suggestionTransform.GetComponentInChildren<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener( () =>
            {
                inputField.Select();
                inputField.text = ReplaceTag( inputField.text, tagInput, tag );
                StartCoroutine( MoveTextEndDelayed() );
            } );
        }
    
        private System.Collections.IEnumerator MoveTextEndDelayed()
        {
            yield return null;
            inputField.MoveTextEnd( false );
        }
    
        /// <summary>
        /// Gets the tag starting with the given input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private FieldInfo GetTagStartingWith( string input )
        {
            return fields.Find( field => field.Name.StartsWith( input ) );
        }
    
        /// <summary>
        /// Gets all the tags starting with the given input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> GetTagsStartingWith( string input )
        {
            return fields.FindAll( field => field.Name.StartsWith( input ) ).Select( field => field.Name ).ToList();
        }
    
        /// <summary>
        /// Replaces the value in the input by the tagName
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public string ReplaceTag( string input, string value, string tagName )
        {
            var fieldInfo = fields.Find( field => field.Name.CompareTo( tagName ) == 0 );
            if ( fieldInfo != null )
                return input.Replace( value, fieldInfo.GetValue( this ).ToString() );
    
            return input;
        }
    }
