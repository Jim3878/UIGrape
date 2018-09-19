using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Grape
{
    [Flags]
    public enum BtnState
    {
        NORMAL = 0x00,
        HIGHLIGHT = 0x01,
        PRESS = 0x02,
        DISABLE = 0x04,
    }
    
    public abstract class BaseButton : BaseUI
    {
        protected BtnState _state;
        public EventHandler onTrigger;
        public BtnState State { get { return _state; } }

        protected void PushState(BtnState state)
        {
            _state |= state;
        }

        protected void RemoveState(BtnState state)
        {
            if (IsState(state))
                _state ^= state;
        }

        public bool IsState(BtnState state)
        {
            return state == (_state & state);
        }
    }
}