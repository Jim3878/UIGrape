using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Grape
{
    public class ToggleTrigger : MouseTrigger
    {
        public override void OnPointerDown(PointerEventData eventData)
        {
            _isDown = true;
            if (onDown != null)
            {
                onDown();
            }
            if (onClick != null)
            {
                onClick();
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            _isDown = false;
            if(onUp != null)
            {
                onUp();
            }
        }
    }
}