            get
            {
                return this._value2;
            }
            set
            {
                System.ComponentModel.DataAnnotations.ValidationContext validatorPropContext = new System.ComponentModel.DataAnnotations.ValidationContext(this, null, null);
                validatorPropContext.MemberName = "value2";
                Validator.ValidateProperty(value, validatorPropContext);
                this._value2 = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("value4", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.ComponentModel.DataAnnotations.RangeAttribute(5, 6)]
        public List<int> value4
        {
            get
            {
                return this._value4;
            }
            set
            {
                System.ComponentModel.DataAnnotations.ValidationContext validatorPropContext = new System.ComponentModel.DataAnnotations.ValidationContext(this, null, null);
                validatorPropContext.MemberName = "value4";
                Validator.ValidateProperty(value, validatorPropContext);
                this._value4 = value;
            }
        }
