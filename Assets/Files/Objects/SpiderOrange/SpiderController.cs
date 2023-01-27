using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
// See author attribution in the Attribution.txt file contained in this directory.
// Helpful video: https://www.youtube.com/watch?v=mJu-zdZ9dyE

public class SpiderController : MonoBehaviour
{
  private NavMeshAgent agent;
  private Animator animator;
  public string tagSearchName; // This will only be used if target is not set.
  private GameObject target = null;
  private DateTime lastAttackCooldown;
  public int attackDelayMS; // Attack delay, in milliseconds

  // Start is called before the first frame update
  void Start() {
    agent = this.gameObject.GetComponent<NavMeshAgent>();
    animator = this.gameObject.GetComponent<Animator>();
    lastAttackCooldown = DateTime.Now;
    target = GameObject.FindGameObjectWithTag("Player"); // Attempt to find the MainCharacter if target is not set
    if(target == null) {
      Debug.Log("Error: Enemy \"" + this.name + "\" is not set to follow any target");
      //Debug.Log("Error: Enemy \"" + this.name + "\" was unable to find the target \"" + target.name + "\". Navigation script will be disabled.");
      enabled = false; // Disable this script.
    }
  }

  // Update is called once per frame
  void Update() {
    agent.SetDestination(target.transform.position);
    
    if(agent.velocity.sqrMagnitude < 0.1F) { // Animate if moving
      animator.SetBool("isWalking", false);

    } else {
      animator.SetBool("isWalking", true);
    }
    
    // Check if close enough to the player to attack
    if(agent.remainingDistance <= agent.stoppingDistance && DateTime.Now > lastAttackCooldown.AddMilliseconds(attackDelayMS)) {
      animator.ResetTrigger("AttackTrigger");
      animator.SetTrigger("AttackTrigger");
    }
  }
}
