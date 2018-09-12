using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grape
{
    public abstract class BaseUI : MonoBehaviour, IGrape
    {
        private bool pLock, gLock;
        private List<IGrape> childList = new List<IGrape>();

        public bool IsLock
        {
            get
            {
                return pLock || gLock;
            }
        }

        public abstract void Init();

        public void SetGlobalLock(bool value)
        {
            this.gLock = value;
            foreach (var child in childList)
            {
                child.SetGlobalLock(value);
            }
        }

        public void SetPrivateLock(bool value)
        {
            this.pLock = value;
        }

        public void Destory()
        {
            foreach (var child in childList)
            {
                child.Destory();
            }
        }

        protected virtual void DoDestory() { }

        private void OnDestroy()
        {
            this.Destory();
        }
    }
}