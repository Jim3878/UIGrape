using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI.Grape
{
    public abstract class BasePlat : BaseUI
    {
        public event EventHandler OnOpen, OnClose;
        public abstract bool DoOpen();

        protected void InvokeOnOpen(EventArgs e)
        {
            if (OnOpen != null)
                OnOpen(this, e);
        }

        protected void InvokeOnCLose(EventArgs e)
        {
            if (OnClose != null)
                OnClose(this, e);
        }

    }
}