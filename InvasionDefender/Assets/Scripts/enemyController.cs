using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void touchUp()
    {
        Debug.Log("touchUp() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
    }
    public void touchDown()
    {
        Debug.Log("touchDown() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
    }
    public void touchMove()
    {
        Debug.Log("touchMove() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
    }
    public void touchExit()
    {
        Debug.Log("touchExit() being called");
        Debug.Log("You are touching a " + this.tag + " Object.");
    }
}
