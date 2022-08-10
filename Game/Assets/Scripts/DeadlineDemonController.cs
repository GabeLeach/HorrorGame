using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class DeadlineDemonController : MonoBehaviour
{
    private NavMeshAgent agent = null;
   [SerializeField] private Transform target;

   private Animator anim =null;
    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }
    private void MoveToTarget(){
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();
        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(distanceToTarget <= agent.stoppingDistance){
            anim.SetFloat("Speed", 0f);
            anim.SetTrigger("Attack");
            SceneManager.LoadScene("Level1");

        }
    
    }
    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }
    private void RotateToTarget(){
        transform.LookAt(target);
    }
    private void AttackTarget(){

    }
    private void GetReferences(){
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
}
