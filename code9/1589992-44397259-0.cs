    using AjaxControlToolkit;
    Accordion userAccordion = (Accordion)this.Page.FindControl("UserAccordion");
    AccordionPane shipInfoPane = userAccordion.Panes["ShippingInformation"];
    Panel ShippingAddressPanel = (Panel)shipInfoPane.FindControl("ShippingAddressPanel");
    System.Web.UI.HtmlControls.HtmlGenericControl Div_Main_Shipping_Information = (System.Web.UI.HtmlControls.HtmlGenericControl)ShippingAddressPanel.FindControl("Div_Main_Shipping_Information");
