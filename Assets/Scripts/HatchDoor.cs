using UnityEngine;

public class HatchDoor : MonoBehaviour
{

    private Vector3 rotateTo;

    [SerializeField] private float targetDegrees = 90;
    [SerializeField] private float passiveDegrees = 0;
    [SerializeField] private float speed = 3;


    public void Start()
    {
        Close();
    }
    public void Update()
    {
        Debug.Log(rotateTo);
       

            if (Vector3.Distance(transform.eulerAngles, rotateTo) > 0.01f)
            {
                transform.eulerAngles = Vector3.LerpUnclamped(transform.rotation.eulerAngles, rotateTo, Time.deltaTime * speed);
            }
            else
            {
                transform.eulerAngles = rotateTo;
            }

    }

    public void Open()
    {
        rotateTo = new Vector3(0,0,targetDegrees);
        
    }
    public void Close()
    {

        rotateTo = new Vector3(0, 0, passiveDegrees);
    }

};