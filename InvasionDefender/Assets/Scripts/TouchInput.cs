using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    float ms = 0.1f;
    private GameObject enemy;
    public static Touch curTouch;
    public LayerMask enMask;
	// Use this for initialization


    private void calcFlick(float t, Vector3 start, Vector3 end, GameObject enmy)
    {
        float xF, yF;
        xF = ((end.x - start.x) * -0.8f)/t;
        yF = ((end.y - start.y) * 1.3f) / t;
        Vector3 force = new Vector3(xF,yF,0f);
        enmy.GetComponent<Rigidbody>().AddForce(force);
    }
	// Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                float start = 0, end;
                Vector3 sPos = Vector3.zero,ePos;
                curTouch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Vector3 tPos;
                Debug.DrawRay(ray.origin, ray.direction,Color.red);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("touch began");
                        if (Physics.Raycast(ray, out hit, enMask))
                        {
                            start = Time.deltaTime;
                           
                            enemy = hit.rigidbody.gameObject;
                            sPos = enemy.GetComponent<Rigidbody>().transform.position;
                            
                        }
                        break;
                    case TouchPhase.Moved:
                        Debug.Log("touch Moved");
                        
                        Debug.Log(enemy.gameObject.ToString());
                        break;
                    case TouchPhase.Ended:
                        Debug.Log("touch Ended");
                        if (enemy.gameObject != null)
                        {
                            ePos = enemy.GetComponent<Rigidbody>().transform.position;
                            end = Time.deltaTime;

                            calcFlick(end - start, sPos, ePos, enemy);
                            enemy = null;
                        }
                        break;
                    case TouchPhase.Canceled:
                        Debug.Log("touch Canceled");
                        if (enemy.gameObject != null)
                        {

                            enemy.GetComponent<Rigidbody>().AddForce(0, 0, 0);
                            enemy = null;
                        }
                        break;
                }

                if (enemy != null)
                {
                    tPos = Camera.main.ScreenToWorldPoint(touch.position);
                    enemy.GetComponent<Rigidbody>().transform.position = (new Vector3(tPos.x, tPos.y, enemy.transform.position.z));
                }
                
            }
        }
    }
}
