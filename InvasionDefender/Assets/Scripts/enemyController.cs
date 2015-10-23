using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    bool held = false;
    bool letGo = false;
    float startY, endY,flickForce,startTime,endTime,holdTime;
    Vector3 mousePos;
    bool touched = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void OnCollisionEnter(Collision colObj)
    {
        Debug.Log("enemy entered a collision with "+ colObj.collider.tag);
       
        if (colObj.collider.tag == "floor")
        {
           
           Debug.Log("destroy");
           Destroy(this.gameObject);
            
        }
    }
	void Update () {
#if UNITY_EDITOR
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, this.gameObject.transform.position.z);
#endif
        if(this.gameObject.transform.position.y < 2.07f)
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 2.07f, this.gameObject.transform.position.z);
            
        if (held)
        {
            
            this.gameObject.transform.position = new Vector3(TouchController.touchPos.x,TouchController.touchPos.y,this.gameObject.transform.position.z);
            
        }
        if (Input.touchCount < 1)
        {

            held = false;
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
        letGo = false;
        
        if (!held)
        {
            
            held = true;
            
        }
    }
    public void touchMove()
    {
        Debug.Log("touchMove() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");

    }
    public void touchHold()
    {
        Debug.Log("touchHold() being called");
        Debug.Log("You are holding a " + this.tag + " Object.");
        
    }
    public void touchExit()
    {
        Debug.Log("touchExit() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
        if (held)
            held = false;
    }
    

}
