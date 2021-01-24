    else if (readType == ReadType.ReadAsInt32)
    {
 
    // Snip
            int value;
            ParseResult parseResult = ConvertUtils.Int32TryParse(_stringReference.Chars, _stringReference.StartIndex, _stringReference.Length, out value);
            if (parseResult == ParseResult.Success)
            {
                numberValue = value;
            }
            else if (parseResult == ParseResult.Overflow)
            {
                throw ThrowReaderError("JSON integer {0} is too large or small for an Int32.".FormatWith(CultureInfo.InvariantCulture, _stringReference.ToString()));
            }
            else
            {
                throw ThrowReaderError("Input string '{0}' is not a valid integer.".FormatWith(CultureInfo.InvariantCulture, _stringReference.ToString()));
            }
        }
        numberType = JsonToken.Integer;
    }
 
    // Snip
    // Finally, after successfully parsing the number
    ClearRecentString();
    // index has already been updated
    SetToken(numberType, numberValue, false);
