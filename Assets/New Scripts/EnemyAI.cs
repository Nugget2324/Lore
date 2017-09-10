using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NS
{
    public class EnemyAI : MonoBehaviour
    {
        public float turnSpeed;
        public float range;
        public Transform goal;
        bool look = false;
        public Animator anim;
        EnemyAIDamage enemyAIDamage;
        public bool test;

        NavMeshAgent navEnemy;
        public Transform player;

        void Start()
        {
            anim = GetComponent<Animator>();
            enemyAIDamage = GetComponent<EnemyAIDamage>();
            navEnemy = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            
        }



        public bool inRange()
        {
            //Finds the distance between current transform position to player position
            if(Vector3.Distance(transform.position, player.position) < range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool inRangeToGoal()
        {
            //Finds the distance between current transform position to player position
            if ( Vector3.Distance(transform.position, goal.position) < range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void chase()
        {
            //if not in the range
            if (!inRange())
            {
                //smooth turn towards the player and move towards it
                Vector3 targetDir = player.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * turnSpeed);
                anim.SetFloat("vertical", 2f, 0.1f, Time.deltaTime);
            }           
        }

        //OnTriggerStay == OnTriggerEnter Updates each frame like Update
        public void OnTriggerStay(Collider other)
        {
            //checks if the collision is tagged player and the layermask from another script is in the game layer
            if (other.gameObject.tag == "Player")
            {
                GetComponent<EnemyGoal>().enabled = false;
                chase();
                enemyAIDamage.attackInRange();
            }
            else
            {
                anim.SetFloat("vertical", 0, 0.1f, Time.deltaTime);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            GetComponent<EnemyGoal>().enabled = true;
        }
    }
}
