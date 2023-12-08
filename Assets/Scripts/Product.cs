using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : ProductType
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _triger;
    [SerializeField] private Collider _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _playerPrefab;

    void Update()
    {
        double _distance = Vector3.Distance(_playerPrefab.transform.position, transform.position);
        if (_distance > 1.5f)
        {
            _animator.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _player)
        {
            _animator.enabled = true;
        }
    }
}
