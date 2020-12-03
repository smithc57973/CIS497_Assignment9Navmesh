/*
 * Chris Smith
 * Assignment 9
 * Navmesh script to move an enemy towards the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public GameObject player;
    public float chaseDist = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        float distFromTarget = Vector3.Distance(transform.position, player.transform.position);
        if (distFromTarget > agent.stoppingDistance && distFromTarget < chaseDist)
        {
            agent.destination = player.transform.position;
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {

            agent.destination = transform.position;
            character.Move(Vector3.zero, false, false);
        }
    }
}
