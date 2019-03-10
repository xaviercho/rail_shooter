using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] private float Speed = 30f;
    [Tooltip("In ms^-1")][SerializeField] private float xRange = 20f;
    [Tooltip("In ms^-1")][SerializeField] private float yRange = 12f;
    [SerializeField] GameObject[] guns;

    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float positionYawFactor = 2f;
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float controlRollFactor = -20f;
    private float xThrow, yThrow;
    bool isControllEnabled = true ;

    void OnPlayerDeath() //called by string reference
    {
        isControllEnabled = false;
    }


    void Update()
    {
        if(isControllEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFireing();
        }
    }

    private void ProcessRotation()
    {
        float pitchDuetoPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDuetoControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDuetoPosition + pitchDuetoControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
       
    }

    // Update is called once per frame
	void ProcessTranslation ()
	{
	     xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	     yThrow = CrossPlatformInputManager.GetAxis("Vertical");

	    float xOffsetThisFrame = xThrow * Speed * Time.deltaTime;
	    float yOffsetThisFrame = yThrow * Speed * Time.deltaTime;

	    float rawNewXPos = transform.localPosition.x + xOffsetThisFrame;
	    float clampedXpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

	    float rawNewYPos = transform.localPosition.y + yOffsetThisFrame;
	    float clampedYpos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos,clampedYpos,transform.localPosition.z);
	}

    void ProcessFireing()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

     void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }


}
