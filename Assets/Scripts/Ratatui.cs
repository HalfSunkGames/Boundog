using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ratatui : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;
    
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();    
    }

    void Update()
    {
        if(!inCoRoutine)
            StartCoroutine(DoSomething());
    }
    
    Vector3 getnewRandomPosition ()
    {
        int randomOrNot;
        randomOrNot = Random.Range(0,6);

        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);
        Vector3 pos = new Vector3();
        if (randomOrNot > 0)
            pos = new Vector3(x, 0, z);
        else
            pos = new Vector3(GameObject.Find("Player").transform.position.x, 0, GameObject.Find("Player").transform.position.z);

        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target,path);

        while(!validPath)
        {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target,path);   
        }
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        target = getnewRandomPosition();
        navMeshAgent.SetDestination(target);  
    } 
}
