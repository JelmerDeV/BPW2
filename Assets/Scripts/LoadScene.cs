using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Image fadePanel;
    public string scene;
    public Text interactText;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactText.text = "Press F to interact";
            if(Input.GetKeyDown("f"))
            StartCoroutine(SceneLoad(scene));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            interactText.text = " ";
        }
    }



        private IEnumerator SceneLoad(string sceneToLoad)
    {
        for (float i = 0f; i <= 1; i += Time.deltaTime)
        {

            fadePanel.color = new Color(0, 0, 0, i);
            yield return null;

        }

        SceneManager.LoadScene(sceneToLoad);




    }


};