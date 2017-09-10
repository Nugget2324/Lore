using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS
{
    public class EnemyGoal : MonoBehaviour
    {

        public float turnSpeed;
        public Transform goal;
        public float range;
        EnemyAI enemyAI;
        EnemyAIDamage enemyAIDamage;
        // Use this for initialization
        void Start()
        {
            enemyAIDamage = GetComponent<EnemyAIDamage>();
            enemyAI = GetComponent<EnemyAI>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<EnemyGoal>().enabled == true && !enemyAI.inRangeToGoal())
            {
                Vector3 targetDir = goal.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * turnSpeed);
                enemyAI.anim.SetFloat("vertical", 2f, 0.1f, Time.deltaTime);
            }
        }
    }
}