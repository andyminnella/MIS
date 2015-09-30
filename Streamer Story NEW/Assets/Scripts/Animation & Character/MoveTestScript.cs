using UnityEngine;
using System.Collections;

public class MoveTestScript : MonoBehaviour {

    private Animator anim;
    private float dir;
    private int point;
    //0 = north, 1 = east, 2 = south, 3 = west

	void Start () {
        anim = GetComponent<Animator>();
        dir = 0f;
	}
    //set this up to walk forward in a direction only

    void Update() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.Play("Walk", -1, 0f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.Play("Idle", -1, 0f);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.Play("Idle", -1, 0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (point < 3)
            {
                point++;
            }

            else point = 0;
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (point > 0)
            {
                point--;
            }

            else point = 3;
        }

        switch (point)
        {
            // walking north
            case 0:
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            // walking east
            case 1:
                transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                break;
            // walking south
            case 2:
                transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                break;
            // walking west
            case 3:
                transform.localRotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
                break;

        }

        if (Input.GetKey(KeyCode.W))
        {
            //z going up/down is north/south
            //x going up/down is east/west
            switch (point)
            {
                case 0:
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
                    break;
                case 1:
                    transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
                    break;
                case 2:
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
                    break;
                case 3:
                    transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
                    break;

            }
        }

            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("test");
                //z going up/down is north/south
                //x going up/down is east/west
                switch (point)
                {
                    case 0:
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f * -1);
                        break;
                    case 1:
                        transform.position = new Vector3(transform.position.x + 0.2f * -1, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f * -1);
                        break;
                    case 3:
                        transform.position = new Vector3(transform.position.x - 0.2f * -1, transform.position.y, transform.position.z);
                        break;
                }

            }
        }
}
