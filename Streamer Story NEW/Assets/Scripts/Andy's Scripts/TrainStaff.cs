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

    #region trainStaff functions
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

    #endregion
}
