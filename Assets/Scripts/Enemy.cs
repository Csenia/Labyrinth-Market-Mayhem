using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform _transform;
    public Transform _target;
    private NavMeshAgent _agent;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _agent.SetDestination(_target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            _agent.speed = 0;
            Destroy(_transform.gameObject);
        }
    }
    
}