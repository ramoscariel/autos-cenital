using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class EnemyPath : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject flagsContainer;
    private Vector3[] flagsPos;
    private int targetFlagIndex;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!flagsContainer || !agent) { return; }
        flagsPos = new Vector3[flagsContainer.transform.childCount];
        int i = 0;
        foreach (Transform child in flagsContainer.transform)
        {
            flagsPos[i] = child.position;
            i++;
        }
        targetFlagIndex = 0;
        agent.SetDestination(flagsPos[targetFlagIndex]);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Arrived");
        if (!agent) { return; }
        targetFlagIndex++;
        targetFlagIndex = targetFlagIndex%flagsPos.Length;
        agent.SetDestination(flagsPos[targetFlagIndex]);
    }


}
