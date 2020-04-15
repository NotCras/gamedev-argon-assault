using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("in m/s")][SerializeField] private float xSpeed = 10f;
    [Tooltip("in m")][SerializeField] private float xBound = 4.5f;
    
    [Tooltip("in m/s")][SerializeField] private float ySpeed = 8f;
    [Tooltip("in m")][SerializeField] private float yBound = 2.5f;

    [SerializeField] private GameObject[] blasters;
    
    [Header("Position-based parameters")]
    [SerializeField] private float pitchFactor = -5f;
    [SerializeField] private float yawFactor = 5f;
    
    [Header("Control-based parameters")]
    [SerializeField] private float controlPitchFactor = -24f;
    [SerializeField] private float controlRollFactor = -20f;

    
    private float xThrow;
    private float yThrow;
    private bool isControlEnabled = true;
    
    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProcessHorizontalMovement();
            ProcessVerticalMovement();
            ProcessRotation();
            ProcessFiring();
        }
        
    }

    private void OnPlayerDeath() // called by collisionHandler
    {
        isControlEnabled = false;
    }
    

    private void ProcessHorizontalMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float raw_new_x = transform.localPosition.x + xOffset;
        float new_x = Mathf.Clamp(raw_new_x, -xBound, xBound);

        transform.localPosition = new Vector3(new_x, transform.localPosition.y, transform.localPosition.z);
    }
    
    private void ProcessVerticalMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float raw_new_y = transform.localPosition.y + yOffset;
        float new_y = Mathf.Clamp(raw_new_y, -yBound, yBound);

        transform.localPosition = new Vector3(transform.localPosition.x, new_y, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor;
        
        float yaw = transform.localPosition.x * yawFactor;
        
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActivateBlasters();
            print("Firing blaster");
        }
        else
        {
            DisableBlasters();
        }
    }

    private void ActivateBlasters()
    {
        foreach (GameObject blaster in blasters)
        {
            blaster.SetActive(true);
        }
    }
    
    private void DisableBlasters()
    {
        foreach (GameObject blaster in blasters)
        {
            blaster.SetActive(false);
        }
    }
}
