using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private Image fadeImage;

    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        float timer = 0;

        while ( (timer < fadeDuration))
        {
            timer += Time.deltaTime;

            Color c = fadeImage.color;

            c.a = timer / fadeDuration;

            fadeImage.color = c;

            yield return null;
        }
        
        SceneManager.LoadScene(sceneName);
    }
}

