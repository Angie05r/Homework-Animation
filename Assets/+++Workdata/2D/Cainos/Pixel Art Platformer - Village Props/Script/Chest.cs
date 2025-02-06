using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        //[FoldoutGroup("Reference")]
        public Animator animator;
        
        private bool isOpened;
        private bool isClosed;
       

        //[FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        

        //[FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        //[FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }
    }
    
    
}
