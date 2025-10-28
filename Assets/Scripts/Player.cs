using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private LayerMask interactionMask;
    private Camera cam;
    private IInteractable currentInteractable;
    private OutlineEffect currentOutline;
    //public float interactDistance = 3f;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.E))
         {
             CheckForInteraction();

         }*/
        
        CheckForInteraction();
        if (Input.GetMouseButtonDown(0) && currentInteractable!= null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteraction()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        RaycastHit hit;
        bool didHit = Physics.Raycast(ray, out hit, interactionRange, interactionMask);
        Debug.DrawRay(ray.origin, ray.direction * interactionRange, didHit ? Color.green : Color.red);
        if (didHit)
        {
            
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            OutlineEffect outline = hit.collider.GetComponent<OutlineEffect>();

            if (interactable != null)
            {
                if (currentOutline != outline)
                {
                    ClearOutline();
                    currentOutline = outline;

                    if (currentOutline != null)
                    {
                        currentOutline.ShowOutline(true);
                    }
                }
                currentInteractable = interactable;
                //interactable.Interact();
            }

            else
            {
                ClearOutline();
                currentInteractable = null;
            }
        }

        else
        {
            ClearOutline();
            currentInteractable = null;
        }
    }

    void ClearOutline()
    {
        if (currentOutline != null)
        {
            currentOutline.ShowOutline(false);
            currentOutline = null;
        }
    }
}
