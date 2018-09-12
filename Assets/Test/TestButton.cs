using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grape.Test
{
    [RequireComponent(typeof(MouseTrigger))]
    public class TestButton : BaseButton
    {
        public ColorStateHandle stateHandle;
        public MouseTrigger mTrigger;

        public override void Init()
        {
            stateHandle.Init();
            stateHandle.AsyncState(_state);
            mTrigger = GetComponent<MouseTrigger>();
            mTrigger.onEnter += Ontrigger;
            mTrigger.onExit += Ontrigger;
            mTrigger.onDown += Ontrigger;
            mTrigger.onUp += Ontrigger;
            SetGlobalLock(false);
            SetPrivateLock(false);
        }

        protected override void DoDestory()
        {
            mTrigger.onEnter -= Ontrigger;
            mTrigger.onExit -= Ontrigger;
            mTrigger.onDown -= Ontrigger;
            mTrigger.onUp -= Ontrigger;
        }

        private void Ontrigger()
        {
            Debug.Log(IsLock);
            if (IsLock)
                return;
            
            SetHighLight(mTrigger.IsEnter);
            Debug.Log("isEnter"+ mTrigger.IsEnter+" down"+ mTrigger.IsDown);
            SetPress(mTrigger.IsDown);
        }

        public void SetHighLight(bool isHighlight)
        {
            if (isHighlight)
                PushState(BtnState.HIGHLIGHT);
            else
                RemoveState(BtnState.HIGHLIGHT);
            stateHandle.AsyncState(_state);
        }

        public void SetPress(bool isPress)
        {
            if (isPress)
                PushState(BtnState.PRESS);
            else
                RemoveState(BtnState.PRESS);
            stateHandle.AsyncState(_state);
        }
    }
}