using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    float ms = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                Debug.Log("hit something");
                if (hit.transform.gameObject.tag == "enemy")
                {
                    Vector3 blah = hit.transform.position;
                    Debug.Log("hit enemy");
                    hit.transform.position = Vector3.Lerp(blah, new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, hit.transform.gameObject.transform.position.z),ms);
                    Debug.Log(hit.transform.gameObject.transform.position.z);
                }
            }
            
        }
        
	}
}
