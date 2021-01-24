    public class XmlClasses
    {
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class DCR
        {
            private DCRXcore_PD12M_ALL_PC_NC_Global xcore_PD12M_ALL_PC_NC_GlobalField;
            private DCRDeudasPorProducto deudasPorProductoField;
            /// <remarks/>
            public DCRXcore_PD12M_ALL_PC_NC_Global Xcore_PD12M_ALL_PC_NC_Global
            {
                get
                {
                    return this.xcore_PD12M_ALL_PC_NC_GlobalField;
                }
                set
                {
                    this.xcore_PD12M_ALL_PC_NC_GlobalField = value;
                }
            }
            /// <remarks/>
            public DCRDeudasPorProducto DeudasPorProducto
            {
                get
                {
                    return this.deudasPorProductoField;
                }
                set
                {
                    this.deudasPorProductoField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRXcore_PD12M_ALL_PC_NC_Global
        {
            private ushort xcoreField;
            private string categoria_de_RiesgoField;
            private decimal probabilidad_de_incumplimientoField;
            private DCRXcore_PD12M_ALL_PC_NC_GlobalHorizonteTiempo horizonteTiempoField;
            private DCRXcore_PD12M_ALL_PC_NC_GlobalOdds oddsField;
            private decimal mes_evaluacionField;
            /// <remarks/>
            public ushort Xcore
            {
                get
                {
                    return this.xcoreField;
                }
                set
                {
                    this.xcoreField = value;
                }
            }
            /// <remarks/>
            public string Categoria_de_Riesgo
            {
                get
                {
                    return this.categoria_de_RiesgoField;
                }
                set
                {
                    this.categoria_de_RiesgoField = value;
                }
            }
            /// <remarks/>
            public decimal Probabilidad_de_incumplimiento
            {
                get
                {
                    return this.probabilidad_de_incumplimientoField;
                }
                set
                {
                    this.probabilidad_de_incumplimientoField = value;
                }
            }
            /// <remarks/>
            public DCRXcore_PD12M_ALL_PC_NC_GlobalHorizonteTiempo HorizonteTiempo
            {
                get
                {
                    return this.horizonteTiempoField;
                }
                set
                {
                    this.horizonteTiempoField = value;
                }
            }
            /// <remarks/>
            public DCRXcore_PD12M_ALL_PC_NC_GlobalOdds Odds
            {
                get
                {
                    return this.oddsField;
                }
                set
                {
                    this.oddsField = value;
                }
            }
            /// <remarks/>
            public decimal Mes_evaluacion
            {
                get
                {
                    return this.mes_evaluacionField;
                }
                set
                {
                    this.mes_evaluacionField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRXcore_PD12M_ALL_PC_NC_GlobalHorizonteTiempo
        {
            private decimal desdeField;
            private decimal hastaField;
            /// <remarks/>
            public decimal Desde
            {
                get
                {
                    return this.desdeField;
                }
                set
                {
                    this.desdeField = value;
                }
            }
            /// <remarks/>
            public decimal Hasta
            {
                get
                {
                    return this.hastaField;
                }
                set
                {
                    this.hastaField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRXcore_PD12M_ALL_PC_NC_GlobalOdds
        {
            private byte odds_A_FavorField;
            private decimal odds_EnContraField;
            private decimal obligorAzarField;
            private decimal obligorIncumplimientoField;
            private decimal porcientoDeudorIncumplimientoField;
            private decimal porcientoDeudorNoIncumplimientoField;
            private decimal quantilPoblacionField;
            /// <remarks/>
            public byte Odds_A_Favor
            {
                get
                {
                    return this.odds_A_FavorField;
                }
                set
                {
                    this.odds_A_FavorField = value;
                }
            }
            /// <remarks/>
            public decimal Odds_EnContra
            {
                get
                {
                    return this.odds_EnContraField;
                }
                set
                {
                    this.odds_EnContraField = value;
                }
            }
            /// <remarks/>
            public decimal ObligorAzar
            {
                get
                {
                    return this.obligorAzarField;
                }
                set
                {
                    this.obligorAzarField = value;
                }
            }
            /// <remarks/>
            public decimal ObligorIncumplimiento
            {
                get
                {
                    return this.obligorIncumplimientoField;
                }
                set
                {
                    this.obligorIncumplimientoField = value;
                }
            }
            /// <remarks/>
            public decimal PorcientoDeudorIncumplimiento
            {
                get
                {
                    return this.porcientoDeudorIncumplimientoField;
                }
                set
                {
                    this.porcientoDeudorIncumplimientoField = value;
                }
            }
            /// <remarks/>
            public decimal PorcientoDeudorNoIncumplimiento
            {
                get
                {
                    return this.porcientoDeudorNoIncumplimientoField;
                }
                set
                {
                    this.porcientoDeudorNoIncumplimientoField = value;
                }
            }
            /// <remarks/>
            public decimal QuantilPoblacion
            {
                get
                {
                    return this.quantilPoblacionField;
                }
                set
                {
                    this.quantilPoblacionField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRDeudasPorProducto
        {
            private DCRDeudasPorProductoProducto[] productoField;
            private DCRDeudasPorProductoTotal[] totalField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Producto")]
            public DCRDeudasPorProductoProducto[] Producto
            {
                get
                {
                    return this.productoField;
                }
                set
                {
                    this.productoField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Total")]
            public DCRDeudasPorProductoTotal[] Total
            {
                get
                {
                    return this.totalField;
                }
                set
                {
                    this.totalField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRDeudasPorProductoProducto
        {
            private string estatusImgField;
            private object estatusImg2Field;
            private byte cantidadCuentasField;
            private DCRDeudasPorProductoProductoCreditoAprobado creditoAprobadoField;
            private string totalAdeudadoField;
            private string cuotaField;
            private object enAtrasoField;
            private object enLegalField;
            private string castigadoField;
            private string nombreField;
            /// <remarks/>
            public string EstatusImg
            {
                get
                {
                    return this.estatusImgField;
                }
                set
                {
                    this.estatusImgField = value;
                }
            }
            /// <remarks/>
            public object EstatusImg2
            {
                get
                {
                    return this.estatusImg2Field;
                }
                set
                {
                    this.estatusImg2Field = value;
                }
            }
            /// <remarks/>
            public byte CantidadCuentas
            {
                get
                {
                    return this.cantidadCuentasField;
                }
                set
                {
                    this.cantidadCuentasField = value;
                }
            }
            /// <remarks/>
            public DCRDeudasPorProductoProductoCreditoAprobado CreditoAprobado
            {
                get
                {
                    return this.creditoAprobadoField;
                }
                set
                {
                    this.creditoAprobadoField = value;
                }
            }
            /// <remarks/>
            public string TotalAdeudado
            {
                get
                {
                    return this.totalAdeudadoField;
                }
                set
                {
                    this.totalAdeudadoField = value;
                }
            }
            /// <remarks/>
            public string Cuota
            {
                get
                {
                    return this.cuotaField;
                }
                set
                {
                    this.cuotaField = value;
                }
            }
            /// <remarks/>
            public object EnAtraso
            {
                get
                {
                    return this.enAtrasoField;
                }
                set
                {
                    this.enAtrasoField = value;
                }
            }
            /// <remarks/>
            public object EnLegal
            {
                get
                {
                    return this.enLegalField;
                }
                set
                {
                    this.enLegalField = value;
                }
            }
            /// <remarks/>
            public string Castigado
            {
                get
                {
                    return this.castigadoField;
                }
                set
                {
                    this.castigadoField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Nombre
            {
                get
                {
                    return this.nombreField;
                }
                set
                {
                    this.nombreField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRDeudasPorProductoProductoCreditoAprobado
        {
            private string monedaField;
            private ushort valueField;
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Moneda
            {
                get
                {
                    return this.monedaField;
                }
                set
                {
                    this.monedaField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DCRDeudasPorProductoTotal
        {
            private string total_CreditoAprobadoField;
            private string total_AdeudadoField;
            private string total_CuotaField;
            private object total_EnAtrasoField;
            private object total_EnLegalField;
            private string total_CastigadoField;
            private string idField;
            /// <remarks/>
            public string Total_CreditoAprobado
            {
                get
                {
                    return this.total_CreditoAprobadoField;
                }
                set
                {
                    this.total_CreditoAprobadoField = value;
                }
            }
            /// <remarks/>
            public string Total_Adeudado
            {
                get
                {
                    return this.total_AdeudadoField;
                }
                set
                {
                    this.total_AdeudadoField = value;
                }
            }
            /// <remarks/>
            public string Total_Cuota
            {
                get
                {
                    return this.total_CuotaField;
                }
                set
                {
                    this.total_CuotaField = value;
                }
            }
            /// <remarks/>
            public object Total_EnAtraso
            {
                get
                {
                    return this.total_EnAtrasoField;
                }
                set
                {
                    this.total_EnAtrasoField = value;
                }
            }
            /// <remarks/>
            public object Total_EnLegal
            {
                get
                {
                    return this.total_EnLegalField;
                }
                set
                {
                    this.total_EnLegalField = value;
                }
            }
            /// <remarks/>
            public string Total_Castigado
            {
                get
                {
                    return this.total_CastigadoField;
                }
                set
                {
                    this.total_CastigadoField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ID
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class DeudasPorProducto
        {
            private DeudasPorProductoProducto[] productoField;
            private DeudasPorProductoTotal[] totalField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Producto")]
            public DeudasPorProductoProducto[] Producto
            {
                get
                {
                    return this.productoField;
                }
                set
                {
                    this.productoField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Total")]
            public DeudasPorProductoTotal[] Total
            {
                get
                {
                    return this.totalField;
                }
                set
                {
                    this.totalField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DeudasPorProductoProducto
        {
            private string estatusImgField;
            private object estatusImg2Field;
            private byte cantidadCuentasField;
            private DeudasPorProductoProductoCreditoAprobado creditoAprobadoField;
            private string totalAdeudadoField;
            private string cuotaField;
            private object enAtrasoField;
            private object enLegalField;
            private string castigadoField;
            private string nombreField;
            /// <remarks/>
            public string EstatusImg
            {
                get
                {
                    return this.estatusImgField;
                }
                set
                {
                    this.estatusImgField = value;
                }
            }
            /// <remarks/>
            public object EstatusImg2
            {
                get
                {
                    return this.estatusImg2Field;
                }
                set
                {
                    this.estatusImg2Field = value;
                }
            }
            /// <remarks/>
            public byte CantidadCuentas
            {
                get
                {
                    return this.cantidadCuentasField;
                }
                set
                {
                    this.cantidadCuentasField = value;
                }
            }
            /// <remarks/>
            public DeudasPorProductoProductoCreditoAprobado CreditoAprobado
            {
                get
                {
                    return this.creditoAprobadoField;
                }
                set
                {
                    this.creditoAprobadoField = value;
                }
            }
            /// <remarks/>
            public string TotalAdeudado
            {
                get
                {
                    return this.totalAdeudadoField;
                }
                set
                {
                    this.totalAdeudadoField = value;
                }
            }
            /// <remarks/>
            public string Cuota
            {
                get
                {
                    return this.cuotaField;
                }
                set
                {
                    this.cuotaField = value;
                }
            }
            /// <remarks/>
            public object EnAtraso
            {
                get
                {
                    return this.enAtrasoField;
                }
                set
                {
                    this.enAtrasoField = value;
                }
            }
            /// <remarks/>
            public object EnLegal
            {
                get
                {
                    return this.enLegalField;
                }
                set
                {
                    this.enLegalField = value;
                }
            }
            /// <remarks/>
            public string Castigado
            {
                get
                {
                    return this.castigadoField;
                }
                set
                {
                    this.castigadoField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Nombre
            {
                get
                {
                    return this.nombreField;
                }
                set
                {
                    this.nombreField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DeudasPorProductoProductoCreditoAprobado
        {
            private string monedaField;
            private ushort valueField;
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Moneda
            {
                get
                {
                    return this.monedaField;
                }
                set
                {
                    this.monedaField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DeudasPorProductoTotal
        {
            private string total_CreditoAprobadoField;
            private string total_AdeudadoField;
            private string total_CuotaField;
            private object total_EnAtrasoField;
            private object total_EnLegalField;
            private string total_CastigadoField;
            private string idField;
            /// <remarks/>
            public string Total_CreditoAprobado
            {
                get
                {
                    return this.total_CreditoAprobadoField;
                }
                set
                {
                    this.total_CreditoAprobadoField = value;
                }
            }
            /// <remarks/>
            public string Total_Adeudado
            {
                get
                {
                    return this.total_AdeudadoField;
                }
                set
                {
                    this.total_AdeudadoField = value;
                }
            }
            /// <remarks/>
            public string Total_Cuota
            {
                get
                {
                    return this.total_CuotaField;
                }
                set
                {
                    this.total_CuotaField = value;
                }
            }
            /// <remarks/>
            public object Total_EnAtraso
            {
                get
                {
                    return this.total_EnAtrasoField;
                }
                set
                {
                    this.total_EnAtrasoField = value;
                }
            }
            /// <remarks/>
            public object Total_EnLegal
            {
                get
                {
                    return this.total_EnLegalField;
                }
                set
                {
                    this.total_EnLegalField = value;
                }
            }
            /// <remarks/>
            public string Total_Castigado
            {
                get
                {
                    return this.total_CastigadoField;
                }
                set
                {
                    this.total_CastigadoField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ID
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }
    }
