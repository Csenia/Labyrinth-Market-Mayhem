using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject physicsBulletPrefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Animator _animator;
    private AudioSource _audioSource;
    private float t;
    private float t2;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        t += Time.deltaTime;
        t2 += Time.deltaTime;
        if (Input.GetMouseButton(0) && t >= 0.17)
        {
            GameObject newBullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
            
            newBullet.GetComponentInChildren<Rigidbody>().velocity = spawn.forward * bulletSpeed;
            _animator.SetTrigger("Shot");
            t = 0;
            _audioSource.Play();
        }
        if (Input.GetMouseButton(1) && t2 >= 0.17)
        {
            GameObject newBullet = Instantiate(physicsBulletPrefab, spawn.position, spawn.rotation);
            newBullet.GetComponentInChildren<Rigidbody>().velocity = spawn.forward * bulletSpeed;
            _animator.SetTrigger("Shot");
            t2 = 0;
            _audioSource.Play();
        }
        
    }
    
}
