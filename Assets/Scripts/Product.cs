using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class Product : ProductType
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _triger;
    [SerializeField] private Collider _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _playerPrefab;
    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0f;
    }

    public void OnHoverEnter() // Метод вызывается при наводке на обьект
    {
        _outline.OutlineWidth = 3f;
    }
    
    public void OnHoverExit() // Метод вызывается при убирании обводки на обьект
    {
        _outline.OutlineWidth = 0f;
    }

    void Update()
    {
        // пока закомментил чтобы ошибок не было
        
        /*double distance = Vector3.Distance(_playerPrefab.transform.position, transform.position);
        if (distance > 1.5f)
        {
            _animator.enabled = false;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == _player)
        {
            _animator.enabled = true;
        }
    }
}
