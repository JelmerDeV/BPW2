using UnityEngine;

public class PlayerToggle : MonoBehaviour
{

    [SerializeField] private GameObject small1;
    [SerializeField] private GameObject small2;
    [SerializeField] private GameObject normal1;
    [SerializeField] private PhysicsMaterial2D smooth;
    [SerializeField] private PhysicsMaterial2D rough;
    [SerializeField]private Color activatedColor;
    [SerializeField] private Color deActivatedColor;
    [SerializeField] private Camera mainCam;



    public int currstate = 0;
    private int currControl;
    private GameObject movingObject;

    private bool smallActivated = false;

   // public static PlayerToggle singleton;

    //private void Awake()
    //{

    //    if (!(singleton is null) && singleton != this)
    //        Destroy(this);
    //    singleton = this;
    //    //DontDestroyOnLoad(gameObject);

    //}

    private void Start()
    {
        Application.targetFrameRate = 60;
        ToggleSize();

    }


    private void Update()
    {
        if (Input.GetKeyDown("e")){
            ToggleSize();
        }
        if (Input.GetKeyDown("q"))
        {
            toggleActivation();
        }

        //mainCam.transform.position = new Vector3(movingObject.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
    }

    public void ToggleSize()
    {
        switch (currstate)
        {
            case 0:
                Combine();
                break;
            case 1:
                Splice();
                break;
            default:
                break;
        }
    }
    public void ToggleSmallControl()
    {

    }

    private void Splice()
    {
        small1.SetActive(true);
        small1.transform.position = normal1.transform.position;
        small2.SetActive(true);
        small2.transform.position = normal1.transform.position;
        normal1.tag = "InactivePlayer";
        normal1.SetActive(false);
        currstate = 0;
        toggleActivation();
        //Debug.Log("test");
    }

    private void Combine()
    {
        float dist = Vector3.Distance(small1.transform.position, small2.transform.position);
        if (dist > 1f)
            return;
        //print("Distance to other: " + dist);

        normal1.SetActive(true);
        normal1.tag = "Player";
        movingObject = normal1;
        normal1.transform.position = small1.transform.position;
        small1.tag = "InactivePlayer";
        small2.tag = "InactivePlayer";
        small1.SetActive(false);
        small2.SetActive(false);
        currstate = 1;
    }

    public void toggleActivation()
    {
        if (currstate == 0) {
            smallActivated = !smallActivated;
            //Debug.Log(smallActivated);

            if (!smallActivated)
            {
                small1.tag = "Player";
                small2.tag = "InactivePlayer";
                small1.GetComponent<PlayerMovement>().canMove = true;
                small2.GetComponent<PlayerMovement>().canMove = false;
                small1.GetComponent<BoxCollider2D>().sharedMaterial = smooth;
                small2.GetComponent<BoxCollider2D>().sharedMaterial = rough;
                small1.GetComponent<SpriteRenderer>().color = activatedColor;
                small2.GetComponent<SpriteRenderer>().color = deActivatedColor;
                movingObject = small1;

            }
            else if (smallActivated)
            {
                small2.tag = "Player";
                small1.tag = "InactivePlayer";
                small1.GetComponent<PlayerMovement>().canMove = false;
                small2.GetComponent<PlayerMovement>().canMove = true;
                small1.GetComponent<BoxCollider2D>().sharedMaterial = rough;
                small2.GetComponent<BoxCollider2D>().sharedMaterial = smooth;
                small1.GetComponent<SpriteRenderer>().color = deActivatedColor;
                small2.GetComponent<SpriteRenderer>().color = activatedColor;
                movingObject = small2;
            }
        }

    }



};