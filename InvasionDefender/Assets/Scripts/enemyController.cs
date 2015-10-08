using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    bool held = false;
    Vector3 mousePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void OnTriggerEnter()
    {
        Debug.Log("enemy entered a collision with ");
    }
	void Update () {
#if UNITY_EDITOR
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y-4.5f, this.gameObject.transform.position.z);
#endif
        if(Input.touchCount > 0)
            mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y - 4.5f, this.gameObject.transform.position.z);
        if (held)
        {
            
            this.gameObject.transform.position = mousePos;
            mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, this.gameObject.transform.position.z);
        }
        if (this.gameObject.transform.position.y < 3.429999)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 3.429999f, this.gameObject.transform.position.z);
        }
	}
    public void touchUp()
    {
        Debug.Log("touchUp() being called");
        Debug.Log("You let go of a " + this.tag + " Object.");
        if (held)
            held = false;
        
    }
    public void touchStart()
    {
        Debug.Log("touchStart() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
        if(!held)
            held = true;
    }
    public void touchMove()
    {
        Debug.Log("touchMove() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");

        if (!held)
            held = true;
    }
    public void touchHold()
    {
        Debug.Log("touchHold() being called");
        Debug.Log("You are holding a " + this.tag + " Object.");
        if (!held)
            held = true;
    }
    public void touchExit()
    {
        Debug.Log("touchExit() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
        if (held)
            held = false;
    }
    

}
