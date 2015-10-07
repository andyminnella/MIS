using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchController : MonoBehaviour
{
    public LayerMask touchInputMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;
    Ray ray;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, touchInputMask))
            {
                GameObject reciever = hit.transform.gameObject;
                touchList.Add(reciever);
                if (Input.GetMouseButtonDown(0))
                {
                    reciever.SendMessage("touchDown", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("touch press active");
                }
                if (Input.GetMouseButtonUp(0))
                {
                    reciever.SendMessage("touchUp", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("touch lifted");
                }
                if (Input.GetMouseButton(0))
                {
                    reciever.SendMessage("touchMove", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("touch has moved");
                }

            }

            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("touchExit", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("touch has exited");
                }
            }
#endif

            if (Input.touchCount > 0)
            {
                touchesOld = new GameObject[touchList.Count];
                touchList.CopyTo(touchesOld);
                touchList.Clear();
                foreach (Touch touch in Input.touches)
                {
                    ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hit, touchInputMask))
                    {
                        GameObject reciever = hit.transform.gameObject;
                        touchList.Add(reciever);
                        if (touch.phase == TouchPhase.Began)
                        {
                            reciever.SendMessage("touchDown", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("touch press active");
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            reciever.SendMessage("touchUp", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("touch lifted");
                        }
                        if (touch.phase == TouchPhase.Moved)
                        {
                            reciever.SendMessage("touchMove", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("touch has moved");
                        }
                        if (touch.phase == TouchPhase.Canceled)
                        {
                            reciever.SendMessage("touchExit", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("touch has exited");
                        }
                    }
                }
                foreach (GameObject g in touchesOld)
                {
                    if (!touchList.Contains(g))
                    {
                        g.SendMessage("touchExit", SendMessageOptions.DontRequireReceiver);
                        Debug.Log("touch has exited");
                    }
                }
            }
        }
    }
}
