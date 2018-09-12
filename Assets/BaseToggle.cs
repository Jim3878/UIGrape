using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grape
{
    [RequireComponent(typeof(ToggleTrigger))]
    public class BaseToggle : BaseButton
    {
        private bool _isOn = false;
        public bool IsOn
        {
            get
            {
                return _isOn;
            }
        }
        private MouseTrigger mTrigger;
        public BaseStateHandle stateHandle;
        public event Action<bool> isTrigger;

        public override void Init()
        {
            mTrigger = GetComponent<ToggleTrigger>();
            mTrigger.onClick += OnTrigger;
            stateHandle = GetComponent<BaseStateHandle>();
            stateHandle.Init();
        }

        protected override void DoDestory()
        {
            mTrigger.onClick -= OnTrigger;
        }

        private void OnTrigger()
        {
            if (IsLock)
                return;

            _isOn ^= true;
            SetValue(IsOn);

        }

        public void SetValue(bool value)
        {
            if (value)
                base.PushState(BtnState.PRESS);
            else
                base.RemoveState(BtnState.PRESS);
            stateHandle.AsyncState(_state);
            if (isTrigger != null)
            {
                isTrigger(IsOn);
            }
        }

        public void SetHighlight(bool isHighlight)
        {
            if (isHighlight)
                base.PushState(BtnState.HIGHLIGHT);
            else
                base.RemoveState(BtnState.PRESS);
            stateHandle.AsyncState(_state);
        }

    }
}