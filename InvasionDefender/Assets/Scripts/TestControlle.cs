using UnityEngine;
using System.Collections;

public class TestControlle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (this.GetComponent<Rigidbody>().transform.position.y > 10)
            this.GetComponent<Rigidbody>().transform.position = new Vector3(this.gameObject.transform.position.x, 10f, this.gameObject.transform.position.z);
        if (this.GetComponent<Rigidbody>().transform.position.x > 9.2f)
            this.GetComponent<Rigidbody>().transform.position = new Vector3(9.2f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        if (this.GetComponent<Rigidbody>().transform.position.x < -9.2f)
            this.GetComponent<Rigidbody>().transform.position = new Vector3(-9.2f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.tag);
    }

    
}
