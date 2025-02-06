using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventChest : MonoBehaviour
{
    public Animator animator; 
    private bool isOpen = false; 
    

    public void OpenChest()
    {
        isOpen = true;
        animator.Play("AM Chest Silver - Open" ); 
        
    }
}
