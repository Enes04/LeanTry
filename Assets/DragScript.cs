using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lean.Touch
{
    public class DragScript : MonoBehaviour
    {
        bool stay;
        Vector2 firstpos;
        float xdistances;
        float ydistances;
        float nowxpos;
        float nowypos;
        public Image imageX;
        public Image imageY;

        protected virtual void OnEnable()
        {
            // Hook into the events we need
            LeanTouch.OnFingerDown += HandleFingerDown;
            LeanTouch.OnFingerUpdate += HandleFingerUpdate;
            LeanTouch.OnFingerUp += HandleFingerUp;
        }

        protected virtual void OnDisable()
        {
            // Unhook the events
            LeanTouch.OnFingerDown -= HandleFingerDown;
            LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
            LeanTouch.OnFingerUp -= HandleFingerUp;
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        public void HandleFingerUp(LeanFinger finger)
        {
            stay = false;
            imageX.fillAmount = 0;
            imageY.fillAmount = 0;
        }
        public void HandleFingerDown(LeanFinger finger)
        {
            stay = true;
            firstpos = finger.ScreenPosition;
        }
        public void HandleFingerUpdate(LeanFinger finger)
        {
            nowxpos = finger.ScreenPosition.x;
            nowypos = finger.ScreenPosition.y;
        }
        // Update is called once per frame
        void Update()
        {
            if (stay == true)
            {
                xdistances = nowxpos - firstpos.x;
                ydistances = nowypos - firstpos.y;
                if (xdistances > 0)
                {
                    imageX.fillOrigin = (int)Image.OriginHorizontal.Left;
                    imageX.fillAmount = (xdistances * 100 / (Screen.width) / 100);
                }
                else if (xdistances < 0)
                {
                    print(xdistances);
                    imageX.fillOrigin = (int)Image.OriginHorizontal.Right;
                    imageX.fillAmount = Mathf.Abs((xdistances * 100 / (Screen.width) / 100));
                }

                if (ydistances > 0)
                {
                    imageY.fillOrigin = (int)Image.OriginVertical.Bottom;
                    imageY.fillAmount = (ydistances * 100 / (Screen.height) / 100);
                }
                else if (ydistances < 0)
                {
                    imageY.fillOrigin = (int)Image.OriginVertical.Top;
                    imageY.fillAmount = Mathf.Abs(ydistances * 100 / (Screen.height) / 100);
                }
            }
          
        }
    }
}

