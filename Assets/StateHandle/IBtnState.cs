using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grape {
    public interface IStateHandle {

        void AsyncState(BtnState state);
    }

    public abstract class BaseStateHandle : BaseGrape, IStateHandle
    {
        public abstract void AsyncState(BtnState state);
    }
}