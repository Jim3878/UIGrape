using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Grape
{
    public class MouseTrigger : EventTrigger
    {
        protected bool _isDown, _isEnter;
        protected float _downTime;
        public Action onClick,onEnter,onExit,onDown,onUp;

        public bool IsDown
        {
            get
            {
                return _isDown;
            }
        }
        public float DownTime
        {
            get
            {
                return _downTime;
            }
        }
        public bool IsEnter
        {
            get
            {
                return _isEnter;
            }
        }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            _isDown = true;
            _downTime = Time.time;
            if (onDown != null)
                onDown();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            _isEnter = true;
            if (onEnter != null)
                onEnter();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            _isEnter = false;
            if (onExit != null)
                onExit();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            _isDown = false;
            if (onUp != null)
                onUp();
            if(_isEnter&& onClick != null)
            {
                onClick();
            }
        }
    }
}