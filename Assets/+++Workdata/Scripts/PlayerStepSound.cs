using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class PlayerStepSound : MonoBehaviour
{
    #region private Viarbles
    [SerializeField] private LayerMask groundLayer; // fragen nach einem Groundlayer
    [SerializeField] private float raycastDistance = 0.2f; // guck auf welches object als erstes trifft
    [SerializeField] private Vector3 raycastPosition;

    [SerializeField] private AudioSource audioSource; // kann auf AudioSource zugreifen

    [Header("Walksound")]
    [SerializeField] private AudioClip[]grassWalkStepSounds;
    [SerializeField] private AudioClip[]mudWalkStepSounds;
    [SerializeField] private AudioClip[]woodWalkStepSounds;
    [SerializeField] private AudioClip[]defaultWalkStepSounds; // mit F2 kann mann es einfacher ändern(ändert es dann überall)
    // bei Einstellungen in KeyMap gucken ob es auf ReSharper ist
    
    [Header("Runsound")]
    [SerializeField] private AudioClip[]grassRunStepSounds;
    [SerializeField] private AudioClip[]mudRunStepSounds;
    [SerializeField] private AudioClip[]woodRunStepSounds;
    [SerializeField] private AudioClip[]defaultRunStepSounds;
    
    [Header("Jumpsound")]
    [SerializeField] private AudioClip[]grassJumpStepSounds;
    [SerializeField] private AudioClip[]mudJumpStepSounds;
    [SerializeField] private AudioClip[]woodJumpStepSounds;
    [SerializeField] private AudioClip[]defaultJumpStepSounds;
    
    [Header("Dashsound")]
    [SerializeField] private AudioClip[]grassDashStepSounds;
    [SerializeField] private AudioClip[]mudDashStepSounds;
    [SerializeField] private AudioClip[]woodDashStepSounds;
    [SerializeField] private AudioClip[]defaultDashStepSounds;

    [Header("Rollsound")]
    [SerializeField] private AudioClip[]grassRollStepSounds;
    [SerializeField] private AudioClip[]mudRollStepSounds;
    [SerializeField] private AudioClip[]woodRollStepSounds;
    [SerializeField] private AudioClip[]defaultRollStepSounds;


    #endregion
    
    void PlayRandomSound(AudioClip[] audioClips)
    {
        int index = Random.Range(0, audioClips.Length); // kann unedlich audios im inspector einfügen bei Audio Source
        audioSource.PlayOneShot(audioClips[index]);
    }
    
    public void PlayWalkStepSound()
    {
        Debug.Log("Stepping Sounds");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastPosition, 
            UnityEngine.Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            string groundTag = hit.collider.gameObject.tag;

            switch (groundTag) // switch benutzt worden
            {
                case "Gras":
                    PlayRandomSound(grassWalkStepSounds);
                    break;
                   
                case "Mud":
                    PlayRandomSound(mudWalkStepSounds);
                    break;
                   
                case "Wood":
                    PlayRandomSound(woodWalkStepSounds);
                    break;

                default:
                    PlayRandomSound(defaultWalkStepSounds);
                    break; 
            }
            
            
        }
        
    }              

    public void PlayRunStepSound()
    {
        Debug.Log("Stepping Sounds");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastPosition, 
            UnityEngine.Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            string groundTag = hit.collider.gameObject.tag;

            switch (groundTag) // switch benutzt worden
            {
                case "Gras":
                    PlayRandomSound(grassRunStepSounds);
                    break;
                   
                case "Mud":
                    PlayRandomSound(mudRunStepSounds);
                    break;
                   
                case "Wood":
                    PlayRandomSound(woodRunStepSounds);
                    break;
                
                default:
                    PlayRandomSound(defaultRunStepSounds);
                    break;
                    
            }
        }
        
    }
    
    public void PlayJumpStepSound()
    {
        Debug.Log("Stepping Sounds");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastPosition, 
            UnityEngine.Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            string groundTag = hit.collider.gameObject.tag;

            switch (groundTag) // switch benutzt worden
            {
                case "Gras":
                    PlayRandomSound(grassJumpStepSounds);
                    break;
                   
                case "Mud":
                    PlayRandomSound(mudJumpStepSounds);
                    break;
                   
                case "Wood":
                    PlayRandomSound(woodJumpStepSounds);
                    break;
                
                default:
                    PlayRandomSound(defaultJumpStepSounds);
                    break;
                    
            }
        }
    }
    
    public void PlayDashStepSound()
    {
        Debug.Log("Stepping Sounds");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastPosition, 
            UnityEngine.Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            string groundTag = hit.collider.gameObject.tag;

            switch (groundTag) // switch benutzt worden
            {
                case "Gras":
                    PlayRandomSound(grassDashStepSounds);
                    break;
                   
                case "Mud":
                    PlayRandomSound(mudDashStepSounds);
                    break;
                   
                case "Wood":
                    PlayRandomSound(woodDashStepSounds);
                    break;
                
                default:
                    PlayRandomSound(defaultDashStepSounds);
                    break;
                    
            }
        }
    }
    
    public void PlayRollStepSound()
    {
        Debug.Log("Stepping Sounds");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastPosition, 
            UnityEngine.Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            string groundTag = hit.collider.gameObject.tag;

            switch (groundTag) // switch benutzt worden
            {
                case "Gras":
                    PlayRandomSound(grassRollStepSounds);
                    break;
                   
                case "Mud":
                    PlayRandomSound(mudRollStepSounds);
                    break;
                   
                case "Wood":
                    PlayRandomSound(woodRollStepSounds);
                    break;
                
                default:
                    PlayRandomSound(defaultRollStepSounds);
                    break;
                    
            }
        }
    }
    
}