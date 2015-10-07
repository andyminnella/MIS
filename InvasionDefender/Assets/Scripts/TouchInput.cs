using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    float ms = 0.1f;
    private GameObject enemy;
    public static Touch curTouch;
	// Use this for initialization
	
	
	// Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                curTouch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Physics.Raycast(ray, out hit);
                Debug.DrawRay(ray.origin, ray.direction,Color.red);
                if (hit.collider != null)
                {
                    
                    if (hit.collider.tag == "enemy")
                    {
                         enemy = hit.collider.transform.gameObject;
                        Debug.Log("enemy hit by raycast");
                        
                    }
                }
                else
                    Debug.Log("hit is null");
                
                if(enemy != null)
                    enemy.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
                
            }
        }
    }
}
