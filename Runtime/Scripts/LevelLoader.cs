using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Src.UI
{
    /**
     * Utility class to switch between scenes using a fade in/fade out.
     */
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;
        public float transitionTime;
        private static readonly int Start1 = Animator.StringToHash("Start");

        /*
         * Using a coroutine to handle the scene switching to the next scene (based on our build index).
         */
        public void StartTransitionToNextLevel()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        
        /*
         * Using a coroutine to handle the scene switching to a specific scene.
         */
        public void StartTransitionTo(int level)
        {
            StartCoroutine(LoadLevel(level));
        }

        /*
         * The effect is achieved by:
         * - Triggering an animation that changes the alpha of a black bg that it's on top of everything in the scene.
         * - Waiting the time needed for the animation to complete.
         * - Using the scene manager to move to the corresponding scene.
         */
        private IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger(Start1);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(levelIndex);
        }
    }
}
