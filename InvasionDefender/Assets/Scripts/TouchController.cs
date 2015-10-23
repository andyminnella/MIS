using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchController : MonoBehaviour 
{
    private Ray ray;
    private RaycastHit rHit;
    private GameObject reciever;
    public LayerMask enemyMask;
    public static Vector3 touchPos;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            
                
                touchPos = ray.origin;
                if (Physics.Raycast(ray, out rHit, 100, enemyMask))
                {
                    reciever = rHit.collider.gameObject;
                    switch (Input.GetTouch(0).phase)
                    {
                        case TouchPhase.Began:
                            reciever.SendMessage("touchStart", SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Ended:
                            reciever.SendMessage("touchUp", SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Canceled:
                            reciever.SendMessage("touchExit", SendMessageOptions.DontRequireReceiver);
                            break;
                    }
                    Debug.Log("raycast hit with enemy");
                    Debug.DrawRay(ray.origin, ray.direction);
                }

            
        }
    }
}
