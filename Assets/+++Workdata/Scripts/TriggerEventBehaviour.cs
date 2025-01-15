using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent onTrigger;

    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    
    public CinemachineVirtualCamera zoomCam;
    public CinemachineVirtualCamera playerCam;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print(other.name);
            //print(other,gameObject.name);  ->längere Version

            zoomCam.Priority = 10;
            playerCam.Priority = 0;
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        zoomCam.Priority = 0;
        playerCam.Priority = 10;
        }
    }
    
    
}
