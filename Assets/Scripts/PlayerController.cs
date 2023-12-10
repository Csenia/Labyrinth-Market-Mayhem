using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float sensetivity = 5f;
    [SerializeField] private GameObject CameraGameObject;
    [SerializeField] private Rigidbody rb;
    private AudioSource _audioSource;
    private float _xRotation;
    private float sprintSpeed;
    private Transform cameraTransform;
    private bool canJump = true;
    private Product previousProduct;
    private void Start()
    {
        cameraTransform = CameraGameObject.transform;
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        float rotationHorizontalInput = Input.GetAxis("Mouse X");
        float rotationVerticalInput = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 2;
        }
        else
        {
            sprintSpeed = 1;
        }

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, 200f, 0));
            canJump = false;
        }
        
        if (Input.GetKey(KeyCode.I))
        {
            rb.transform.position = new Vector3(0f, 0f, 0f);
            rb.velocity = new Vector3(0f, 0f, 0f);
            canJump = false;
        }
        
        Vector3 forwardSpeed = verticalInput * transform.forward * speed * sprintSpeed;
        Vector3 rightSpeed = horizontalInput * transform.right * speed * sprintSpeed;
        Vector3 summSpeed = rightSpeed + forwardSpeed;
        
        rb.velocity = new Vector3(summSpeed.x, rb.velocity.y, summSpeed.z);
        
        rb.angularVelocity = new Vector3(0, rotationHorizontalInput * sensetivity * 3f,  0);
        _xRotation += -rotationVerticalInput * sensetivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);
        cameraTransform.localEulerAngles = new Vector3(_xRotation, 0, 0);
        
        
        
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100.0f))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);
            var product = hit.collider.GetComponentInParent<Product>();
            
            if (product != null)
            {
                if (product != this && product != previousProduct)
                {
                    product.OnHoverEnter();
                    previousProduct = product;
                }
            }
            else if (previousProduct != null)
            {
                previousProduct.OnHoverExit();
                Debug.Log("Not");
                previousProduct = null;
            }
        }
        else
        {
            if (previousProduct != null)
            {
                previousProduct.OnHoverExit();
                previousProduct = null;
            }
        }
        

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            canJump = true;
        }
    }
    
}
