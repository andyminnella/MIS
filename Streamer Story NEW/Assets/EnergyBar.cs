using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {
    public GameObject[] percent;

    void Start()
    {
        Debug.Log("Max Energy:  " + MasterGameObject.getMaxEnergy());
        
    }
    void Update()
    {
        switch (MasterGameObject.getMaxEnergy())
        {
            case 99:

                if (MasterGameObject.getTotalEnergy() < 10)
                {

                    for (int i = 0; i < 10; i++)
                        percent[i].SetActive(false);
                }
                else if (MasterGameObject.getTotalEnergy() < 20)
                {
                    for (int i = 0; i < 1; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 30)
                {
                    for (int i = 0; i < 2; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 40)
                {
                    for (int i = 0; i < 3; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 50)
                {
                    for (int i = 0; i < 4; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 60)
                {
                    
                    for (int i = 0; i < 5; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 70)
                {
                    
                    for (int i = 0; i < 6; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 80)
                {
                    
                    for (int i = 0; i < 7; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() < 90)
                {
                    
                    for (int i = 0; i < 8; i++)
                        percent[i].SetActive(true);
                }
                else if (MasterGameObject.getTotalEnergy() == 99)
                {
                    
                    for (int i = 0; i < 9; i++)
                        percent[i].SetActive(true);
                }
                
                break;
                

            case 198:
                if (MasterGameObject.getTotalEnergy() < 20)
                {
                    for (int i = 0; i < 10; i++)
                        percent[i].SetActive(false);
                }
                break;

            case 297:
                if (MasterGameObject.getTotalEnergy() < 30)
                {
                    for (int i = 0; i < 10; i++)
                        percent[i].SetActive(false);
                }
                break;

            case 396:
                if (MasterGameObject.getTotalEnergy() < 40)
                {
                    for (int i = 0; i < 10; i++)
                        percent[i].SetActive(false);
                }
                break;

        }
    }
	
}
