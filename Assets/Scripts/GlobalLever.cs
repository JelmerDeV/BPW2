using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(UnityEngine.UI.Button))]
public class GlobalLever : MonoBehaviour
{
    [SerializeField] private enum Interaction { Door, Hatch, ActivationObject }
    [SerializeField] private Interaction orientation;

    [SerializeField] private GameObject interactionObject;
    [SerializeField] private string tagCheck = "Player";
    [SerializeField] private Transform _pivot;
    private bool canInteract = false;

    private bool _active = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "InactivePlayer")
        {
            canInteract = collision.gameObject.GetComponent<PlayerMovement>().canMove;
        }
        if (collision.tag == tagCheck)
        {

            if (Input.GetKeyDown("f") && canInteract)
            {
                if (_active)
                {
                    LeverActionDeactivate();

                }else if (!_active)
                {
                    LeverActionActivate();
                }
            }

        }
    }


    private void LeverActionActivate()
    {
        _pivot.transform.eulerAngles = new Vector3(0, 0, -30);
        _active = true;
        Debug.Log("Active");
        switch (orientation)
        {
            default:
                return;

            case Interaction.Door:
                Debug.Log("door");
                interactionObject.GetComponent<Door>().Open();
                break;

            case Interaction.Hatch:
                Debug.Log("hatch");
                interactionObject.GetComponent<HatchDoor>().Open();
                break;

            case Interaction.ActivationObject:
                Debug.Log("AO");
                break;
        }
    }

    private void LeverActionDeactivate()
    {
        _pivot.transform.eulerAngles = new Vector3(0,0,30);
        _active = false;
        Debug.Log("Inactive");
        switch (orientation)
        {
            default:
                return;

            case Interaction.Door:
                Debug.Log("door");
                interactionObject.GetComponent<Door>().Close();
                break;

            case Interaction.Hatch:
                Debug.Log("hatch");
                interactionObject.GetComponent<HatchDoor>().Close();
                break;

            case Interaction.ActivationObject:
                Debug.Log("AO");
                break;
        }
    }



};