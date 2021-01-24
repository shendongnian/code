    public static bool LocateInDiagram(this ModelElement element)
    {
        // Validation
        SmartGuard.NotNull(() => element, element);
        // Get the diagram view
        DiagramView diagramView = element.GetActiveDiagramView();
        if (diagramView != null)
        {
            // Select it
            return diagramView.SelectModelElement(element);
        }
        // Default result
        return false;
    }
    public static DiagramView GetActiveDiagramView(this ModelElement element)
    {
        // Validation
        SmartGuard.NotNull(() => element, element);
        // Get the shape that corresponds to this model element
        ShapeElement shapeElement = element.GetShapeElement();
        if (shapeElement != null)
        {
            // Result
            return shapeElement.GetActiveDiagramView();
        }
        // Default result
        return null;
    }
    public static ShapeElement GetShapeElement(this ModelElement element)
    {
        // Validation
        SmartGuard.NotNull(() => element, element);
        // Get the first shape
        // If the model element is in a compartment the result will be null
        ShapeElement shape = element.GetFirstShapeElement();
        if (shape == null)
        {
            // If the element is in a compartment, try to get the parent model element to select that
            ModelElement parentElement = element.GetCompartmentElementFirstParentElement();
            if (parentElement != null)
            {
                shape = parentElement.GetFirstShapeElement();
            }
        }
        // Result
        return shape;
    }
    private static ShapeElement GetFirstShapeElement(this ModelElement element)
    {
        // Presentation elements
        LinkedElementCollection<PresentationElement> presentations = PresentationViewsSubject.GetPresentation(element);
        foreach (PresentationElement presentation in presentations)
        {
            ShapeElement shapeElement = presentation as ShapeElement;
            if (shapeElement != null)
            {
                return shapeElement;
            }
        }
        // Default result
        return null;
    }
    private static ModelElement GetCompartmentElementFirstParentElement(this ModelElement modelElement)
    {
        // Get the domain class associated with model element.
        DomainClassInfo domainClass = modelElement.GetDomainClass();
        if (domainClass != null)
        {
            // A element is only considered to be in a compartment if it participates in only 1 embedding relationship
            // This might be wrong for some models
            if (domainClass.AllEmbeddedByDomainRoles.Count == 1)
            {
                DomainRoleInfo roleInfo = domainClass.AllEmbeddedByDomainRoles[0];
                if (roleInfo != null)
                {
                    // Get a collection of all the links to this model element
                    // Since this is in a compartment there should be at least one
                    // There can be only one.
                    ReadOnlyCollection<ElementLink> links = roleInfo.GetElementLinks(modelElement);
                    if (links.Count == 1)
                    {
                        // Get the model element participating in the link that isn't the current one
                        // That will be the parent
                        // Probably there is a better way to achieve the same result
                        foreach (ModelElement linkedElement in links[0].LinkedElements)
                        {
                            if (!modelElement.Equals(linkedElement))
                            {
                                return linkedElement;
                            }
                        }
                    }
                }
            }
        }
        // Default result
        return null;
    }
    public static DiagramView GetActiveDiagramView(this ShapeElement shape)
    {
        // Validation
        SmartGuard.NotNull(() => shape, shape);
        // Result
        if (shape.Diagram != null)
        {
            return shape.Diagram.ActiveDiagramView;
        }
        // Default result
        return null;
    }
    public static bool SelectModelElement(this DiagramView diagramView, ModelElement modelElement, bool ensureVisible)
    {
        // Validation
        SmartGuard.NotNull(() => diagramView, diagramView);
        SmartGuard.NotNull(() => modelElement, modelElement);
        // Get the shape element that corresponds to the model element
        ShapeElement shapeElement = modelElement.GetPresentation<ShapeElement>();
        if (shapeElement != null)
        {
            // Make sure the shape element is visible (because connectors can be hidden)
            if (!shapeElement.IsVisible)
            {
                shapeElement.Show();
            }
            // Create a diagram item for this shape element and select it
            diagramView.SelectDiagramItem(new DiagramItem(shapeElement), ensureVisible);
            return true;
        }
        // If the model element does not have a shape, try to cast it IModelElementCompartmented
        IModelElementCompartmented compartmentedModelElement = modelElement as IModelElementCompartmented;
        if (compartmentedModelElement != null)
        {
            // Get the parent
            IModelElementWithCompartments parentModelElement = compartmentedModelElement.ParentModelElement;
            if (parentModelElement != null)
            {
                // Get the compartment that stores the model element
                ElementListCompartment compartment = parentModelElement.GetCompartment(compartmentedModelElement.CompartmentName);
                if (compartment == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.RES_Error_CannotFindCompartment, compartmentedModelElement.CompartmentName));
                }
                // Expand the compartment?
                if (!compartment.IsExpanded)
                {
                    using (Transaction trans = modelElement.Store.TransactionManager.BeginTransaction("IsExpanded"))
                    {
                        compartment.IsExpanded = true;
                        trans.Commit();
                    }
                }
                // Find the model element in the compartment
                int index = compartment.Items.IndexOf(modelElement);
                if (index >= 0)
                {
                    // Create a diagram item and select it
                    diagramView.SelectDiagramItem(new DiagramItem(compartment, compartment.ListField, new ListItemSubField(index)), ensureVisible);
                    // Result OK
                    return true;
                }
            }
        }
        // Default result
        return false;
    }
