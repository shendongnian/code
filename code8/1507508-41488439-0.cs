    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class CustomInputField : InputField
    {
    	new public bool Focused = false;
    	new public bool Deactivated = false;
    
    	new public void ActivateInputField()
    	{
    		Focused = true;
    		base.ActivateInputField();
    	}
    
    	public override void OnDeselect(BaseEventData eventData)
    	{
    		Deactivated = true;
    		DeactivateInputField();
    		base.OnDeselect(eventData);
    	}
    		
    	public override void OnPointerClick(PointerEventData eventData)
    	{
    		if(Deactivated)
    		{
    			MoveTextEnd(true);
    			Deactivated = false;
    		}
    		base.OnPointerClick(eventData);
    	}
    
    	protected override void LateUpdate()
    	{
    		base.LateUpdate();
    		if(Focused)
    		{
    			MoveTextEnd(true);
    			Focused = false;
    		}
    	}
    }
