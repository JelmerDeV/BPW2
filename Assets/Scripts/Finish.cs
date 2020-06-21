using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField] private bool canFinish = false;

    public GameOver go;
    public PlayerToggle pt;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && pt.currstate == 1)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        go.StartSequence(true);
    }


};