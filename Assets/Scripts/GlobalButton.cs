using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(UnityEngine.UI.Button))]
public class GlobalButton : MonoBehaviour
{
    [SerializeField]private enum Interaction { Door, Hatch, ActivationObject }
    [SerializeField] private Interaction orientation;

    [SerializeField] private GameObject interactionObject;
    [SerializeField] private string tagCheck;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == tagCheck || other.tag == "InactivePlayer" || other.tag == "Box")
        {
            ButtonAction();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == tagCheck || other.tag == "InactivePlayer" || other.tag == "Box")
        {
            ButtonDeactivate();
        }
    }
    private void Start()
    {

    }


    private void ButtonAction() 
    {
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

    private void ButtonDeactivate()
    {
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