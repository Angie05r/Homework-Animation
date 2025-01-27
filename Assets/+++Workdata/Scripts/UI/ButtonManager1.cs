    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UIElements;

    public class ButtonManager1 : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject optionsMenu;
        //[SerializeField] private GameObject pauseMenu;

        [SerializeField] private Animator fadePanelAnim;

        public void Button_OpenOptionsMenu()
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
    
        public void Button_OpenMainMenu()
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }

        public void Button_NewGame()
        {
            StartCoroutine(FadeInLoadScene());
        }
        
        IEnumerator FadeInLoadScene()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            asyncOperation.allowSceneActivation = false;

            StartCoroutine(DisplayLoading(asyncOperation));
        
            fadePanelAnim.Play("FadePanel_fade in");
            yield return new WaitForSeconds(1);
        
            if (asyncOperation.progress >= 0.9f) 
            {
                yield return new WaitForSeconds(.5f);
                asyncOperation.allowSceneActivation = true;
            }
        }

        IEnumerator DisplayLoading(AsyncOperation asyncOperation)
        {
            print(asyncOperation.progress);
            while (asyncOperation.progress < 1f)
            { 
                yield return null;
                print(asyncOperation.progress);
                    
            }
            
        }
    }

