using UnityEngine;

using UnityEngine.UI;
using System.Collections;

public class Stream : MonoBehaviour
{
    
    #region variables
    
    private int energy, cashPerStream;
    private float length;
    private bool isStreaming;
    private int numInterval = 0;

    public float interval= 4f;
    public int cashPerInt = 2;
    private MasterGameObject.strQuality quaility;
    #endregion
    
    //function that starts the stream takes in energy quality skill charm comp
    public void startStream(int energy, MasterGameObject.strQuality strQuality, int skill, int charm, int comp)
    {
        cashPerInt = Random.RandomRange(1, 15);
        
        isStreaming = true;
        if (energy < 5)
        {
            
            Debug.Log("failed to stream, energy too low");
            return;
        }
        length = energy;
        cashPerStream = cashPerInt;


    }
    //returns cash earned from stream
    public int getCash()
    {
        return cashPerStream;
    }


    
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
