using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private LayerMask interactionMask;
    private Camera cam;
    private IInteractable currentTarget;
    public float interactDistance;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, interactDistance))
            {
                
            }

        }
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteraction();
           
        }*/
    }

    /*void CheckForInteraction()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactionMask))
        {
            currentTarget = hit.collider.GetComponent<IInteractable>();
            if (currentTarget != null)
            {
                currentTarget.Interact();
            }

        }
    }*/
}
