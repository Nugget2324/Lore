using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PI
{

    public class Hook : MonoBehaviour
    {
        Animator anim;
        PlayerInput states;

        // Use this for initialization
        public void Init(PlayerInput st)
        {
            states = st;
            anim = st.anim;
        }

        void OnAnimatorMove()
        {
            if (states.canMove)
                return;

            states.rigid.drag = 0;
            float multi = 1;

            Vector3 delta = anim.deltaPosition;
            delta.y = 0;
            Vector3 v = (delta * multi) / states.delta;
            states.rigid.velocity = v;
        }
    }
}
