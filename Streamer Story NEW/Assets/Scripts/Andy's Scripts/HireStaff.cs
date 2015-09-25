using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HireStaff : MonoBehaviour {
    
    public Text[] comp, skill, charm, energy, cost, name, description;
    private Personnel[] employee = new Personnel[2];
     
	// Use this for initialization

    void Awake()
    {
        Debug.Log(MasterGameObject.instance.getEmp(0) + " employee 0 from mastergame object singleton");
        DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < comp.Length; i++)
        {
            
            employee[i] = MasterGameObject.instance.getEmp(i);
        }
    }
    void Start()
    {
        Debug.Log("getEmp is coming up " +MasterGameObject.instance.getEmp(0));
        if (this == null)
        {
            Debug.Log("hireStaff is null");
        }
        Debug.Log("hire staff is " +this);
        Debug.Log("comp element 0 is " + comp[0].ToString());
        Debug.Log("employee is " + employee[0]);
        
        for (int i = 0; i < comp.Length; i++)
        {
            
            comp[i].text = employee[i].getComp().ToString();
            skill[i].text = employee[i].getSkill().ToString();
            charm[i].text = employee[i].getChr().ToString();
            energy[i].text = employee[i].getEnergy().ToString();
            cost[i].text = "Cost "+employee[i].getCost().ToString()+" /month";
            name[i].text = employee[i].getName();
            description[i].text = employee[i].getDesc();

        }
        Debug.Log(employee[1] + "employee element 1");
	}
    void OnDisable()
    {
        Debug.Log("hire staff script has disabled");
    }
    // Update is called once per frame
    void Update()
    {
	
	}
}
