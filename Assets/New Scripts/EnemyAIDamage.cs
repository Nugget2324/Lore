using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NS
{
    public class EnemyAIDamage : MonoBehaviour
    {
        public LayerMask toAttack;
        public string[] animate;
        public bool timer = false;
        float waitTime;

        Animator anim;
        EnemyAI enemyAI;
        public CapsuleCollider swordCollider;

        void Start()
        {
            enemyAI = GetComponent<EnemyAI>();
            anim = GetComponent<Animator>();
            swordCollider.enabled = false;
        }

        void Update()
        {
            //this is a timer lol
            if(waitTime > 0)
                waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                waitTime = 0;
                timer = false;
            }

        }

        public void attackInRange()
        {
            //checks if im in range to attack and the timer is equal to 0
            if (enemyAI.inRange() && waitTime <= 0f)
            {
                //does the attacking animation in random
                string targetAnim = null;
                int n = Random.Range(1, animate.Length);
                targetAnim = animate[n];
                waitTime = 2f;
                timer = true;
                //if I didnt asign any string name itll just be null
                if (string.IsNullOrEmpty(targetAnim))
                {
                    return;
                }
                //this is animation, takes the string name corresponds to the animation name and plays it
                anim.CrossFade(targetAnim, 0.3f);
            }      
        }
        //these are your hitboxes
        void OpenCollision()
        {
            swordCollider.enabled = true;
        }

        void CloseCollision()
        {
            swordCollider.enabled = false;
        }
    }
}
