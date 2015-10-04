using UnityEngine;
using System.Collections;

public class TrainStaff : MonoBehaviour
{
    #region variables
    public enum trainTypes
    {
        nothing = 0,
        selfStudy,
        tutor,
        specTutor,
        uniCourse,
        geniusDisciple

    }
    //ints to keep track of skill points left
    int maxUp, upPoint = 0;
    trainTypes cTrnType = trainTypes.nothing;
    public int empNumber =-1;
    bool[] isTraining = new bool[4];
    
    public int timeLimit;
	//array to represent stats to be updated
    //comp = 0, skill = 1, charm = 2, energy = 3
    int[] chosenSkills = new int[4];

    #endregion

    
    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            isTraining[i] = false;
        }
        resetSkill();
    }
    void Update()
    {
        //set number of chosen inputs
        switch (cTrnType)
        {
                
            case trainTypes.selfStudy:
                maxUp = 0;
                
                break;

            case trainTypes.tutor:
                maxUp = 1;
                
                break;

            case trainTypes.specTutor:
                maxUp = 1;
                break;

            case trainTypes.uniCourse:
                maxUp = 2;
                break;
            case trainTypes.geniusDisciple:
                maxUp = 5;
                break;
        }
        
    }

    #region trainStaff functions
    void trainStaff(trainTypes trainType, ref Personnel emp)
    {
        int[] rand = new int[2];
        switch (trainType)
        {
            case trainTypes.selfStudy:
                rand[0] = Random.RandomRange(0, 3);
                chosenSkills[rand[0]] += 1;
                emp.setComp(emp.getComp() + chosenSkills[0]);
                emp.setSkill(emp.getSkill() + chosenSkills[1]);
                emp.setChr(emp.getChr() + chosenSkills[2]);
                emp.setEnergy(emp.getChr() + chosenSkills[3]);
                break;

            case trainTypes.tutor:
                emp.setComp(emp.getComp() + chosenSkills[0]);
                emp.setSkill(emp.getSkill() + chosenSkills[1]);
                emp.setChr(emp.getChr() + chosenSkills[2]);
                emp.setEnergy(emp.getChr() + chosenSkills[3]);
                break;

            case trainTypes.specTutor:
                rand[0] = Random.RandomRange(0, 3);
                chosenSkills[rand[0]] += 1;
                emp.setComp(emp.getComp() + chosenSkills[0]);
                emp.setSkill(emp.getSkill() + chosenSkills[1]);
                emp.setChr(emp.getChr() + chosenSkills[2]);
                emp.setEnergy(emp.getChr() + chosenSkills[3]);
                break;
                  
            case trainTypes.uniCourse:
                rand[0] = Random.RandomRange(0, 3);
                rand[1] = Random.RandomRange(0, 3);
                chosenSkills[rand[0]] += 1;
                chosenSkills[rand[1]] += 1;
                emp.setComp(emp.getComp() + chosenSkills[0]);
                emp.setSkill(emp.getSkill() + chosenSkills[1]);
                emp.setChr(emp.getChr() + chosenSkills[2]);
                emp.setEnergy(emp.getChr() + chosenSkills[3]);
                break;
            case trainTypes.geniusDisciple:
       
                emp.setComp(emp.getComp() + chosenSkills[0]);
                emp.setSkill(emp.getSkill() + chosenSkills[1]);
                emp.setChr(emp.getChr() + chosenSkills[2]);
                emp.setEnergy(emp.getChr() + chosenSkills[3]);
                break;
        }

    }

    void resetSkill()
    {
        for (int i = 0; i < 4; i++)
            chosenSkills[i] = 0;
    }
    //timer for training
    IEnumerator timeCounter(int tLimit)
    {
        isTraining[empNumber] = true;
        int t = 0;
        while (t < tLimit)
        {
            yield return new WaitForSeconds(1);
            t++;
            //add number animations here
        }
        isTraining[empNumber] = false;
        Debug.Log("training time counter has ended");
        StopCoroutine(timeCounter(tLimit));
    }

    bool trainAllowed()
    {  
        bool allow = false;
        
        if (isTraining[empNumber] == false)
        {
            allow = true;
        }
        return allow; 
    }

    #endregion

    #region panel functions
    /// <summary>
    /// plus minus buttons for skills,
    /// will only work if upgrade points are available
    /// </summary>
    public void compPlus(){
        if (upPoint > 0)
            chosenSkills[0]++;
        else
            Debug.Log("No upgrade points available");
    }
    public void compMin()
    {
        if (upPoint < maxUp)
            chosenSkills[0]--;
        else
            Debug.Log("No upgrade points SPENT");
    }
    public void skillPlus()
    {
        if (upPoint > 0)
            chosenSkills[1]++;
        else
            Debug.Log("No upgrade points available");
    }
    public void skillMin()
    {
        if (upPoint < maxUp)
            chosenSkills[1]--;
        else
            Debug.Log("No upgrade points SPENT");
    }
    public void charmPlus()
    {
        if (upPoint > 0)
            chosenSkills[2]++;
        else
            Debug.Log("No upgrade points available");
    }
    public void charmMin()
    {
        if (upPoint < maxUp)
            chosenSkills[2]--;
        else
            Debug.Log("No upgrade points SPENT");
    }
    public void energyPlus()
    {
        if (upPoint > 0)
            chosenSkills[3]++;
        else
            Debug.Log("No upgrade points available");
    }
    public void energyMin()
    {
        if (upPoint < maxUp)
            chosenSkills[3]--;
        else
            Debug.Log("No upgrade points SPENT");
    }

    #endregion
}
