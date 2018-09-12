using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grape
{
    public interface IGrape
    {

        bool IsLock { get; }

        void Init();
        void Destory();

        void SetGlobalLock(bool value);
        void SetPrivateLock(bool value);

    }

    public abstract class BaseGrape : MonoBehaviour, IGrape
    {
        private bool globalLock=false,privateLock=false;
        public bool IsLock
        {
            get
            {
                return globalLock || privateLock;
            }
        }

        public abstract void Destory();

        public abstract void Init();

        public virtual void SetGlobalLock(bool value)
        {
            globalLock = value;
        }

        public void SetPrivateLock(bool value)
        {
            privateLock = value;
        }
    }
}