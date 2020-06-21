using UnityEngine;

public class Door : MonoBehaviour
{

    private float targetPos;
    private float openPos;
    private float closedPos;

    [SerializeField] float speed = 2;




    private void Start()
    {
        closedPos = transform.localPosition.y;
        openPos = (transform.localPosition.y + (gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2));
        Close();
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, targetPos, Time.deltaTime * speed), transform.localPosition.z);
    }

    public void Open()
    {
        targetPos = openPos; 
    }

    public void Close()
    {
        targetPos = closedPos;
    }

};