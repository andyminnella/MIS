using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HireStaffPanel : MonoBehaviour {
    
    public MasterGameObject mGO;
    private Personnel[] employees = new Personnel[4];
    public Text[] charm, skill, comp, energy, name, description, cost;

	// Use this for initialization
    void Start()
    {
        if (MasterGameObject.getPersonnel(0) != null)
        {

            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Personnel();
                employees[i] = MasterGameObject.getPersonnel(i);



            }

            //temp loop
            for (int i = 0; i < 2; i++)
            {
                charm[i].text = employees[i].getChr().ToString();
                skill[i].text = employees[i].getSkill().ToString();
                comp[i].text = employees[i].getComp().ToString();
                energy[i].text = employees[i].getEnergy().ToString();
                name[i].text = employees[i].getName();
                description[i].text = employees[i].getDesc();
                cost[i].text = employees[i].getCost().ToString();
            }

        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (MasterGameObject.getPersonnel(0) != null)
        {

            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Personnel();
                employees[i] = MasterGameObject.getPersonnel(i);



            }

            //temp loop
            for (int i = 0; i < 2; i++)
            {
                charm[i].text = employees[i].getChr().ToString();
                skill[i].text = employees[i].getSkill().ToString();
                comp[i].text = employees[i].getComp().ToString();
                energy[i].text = employees[i].getEnergy().ToString();
                name[i].text = employees[i].getName();
                description[i].text = employees[i].getDesc();
                cost[i].text = employees[i].getCost().ToString();
            }

        }
        else
            Debug.Log("personnel from MGO is null");
	}
}
