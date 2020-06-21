using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public static GameOver singleton;

    public Image fadePanel;
    [SerializeField] private string sceneToLoad;



    private void Awake()
    {
        fadePanel.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        for (float i = 0.9f; i >= 0; i -= Time.deltaTime)
        {

            fadePanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    public void StartSequence(bool gameOver)
    {

        StartCoroutine(GameOverSequence(gameOver));
    }

    private IEnumerator GameOverSequence(bool gameOver) 
    {
        for (float i = 0.5f; i <= 1; i += Time.deltaTime)
        {

            fadePanel.color = new Color(0, 0, 0, i);
            yield return null;

        }
        yield return new WaitForSeconds(1);

        if (gameOver)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }

  

};