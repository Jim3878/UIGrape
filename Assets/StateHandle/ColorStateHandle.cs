using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Grape
{
    

    public class ColorStateHandle : BaseStateHandle
    {
        private Image image;
        public Color normal=new Color(1,1,1),
                    highlight = new Color(1, 1, 1), 
                    press = new Color(1, 1, 1),
                    disable = new Color(1, 1, 1);

        public override void Init()
        {
            image = GetComponent<Image>();
        }
        
        public override void Destory()
        {
        }

        public override void AsyncState(BtnState state)
        {
            if (IsState(BtnState.DISABLE, state))
            {
                SetColor(disable);
            }
            else if (IsState(BtnState.PRESS,state))
            {
                SetColor(press);
            }else if (IsState(BtnState.HIGHLIGHT, state))
            {
                SetColor(highlight);
            }else
            {
                SetColor(normal);
            }
        }

        public void SetColor(Color color)
        {
            image.color = color;
        }

        private bool IsState(BtnState target,BtnState state)
        {
            return target == (state & target);
        }
    }
}