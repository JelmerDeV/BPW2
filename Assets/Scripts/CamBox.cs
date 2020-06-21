using UnityEngine;

public class CamBox : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            Camera.main.transform.position = this.transform.position;
        }

    }
};