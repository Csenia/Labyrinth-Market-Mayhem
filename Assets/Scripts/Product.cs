using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class Product : PassiveItem
{
    [SerializeField] private Collider _collider;

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


    public override void Affect()
    {
        base.Affect();
        ScoreManager.Instance.AddScore(itemType, transform.position);
    }
}
