using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class EnemyPath : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject flagsContainer;
    private Flag[] flags;
    private int targetFlagIndex;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!flagsContainer || !agent) { return; }
        flags = new Flag[flagsContainer.transform.childCount];
        int i = 0;
        foreach (Transform child in flagsContainer.transform)
        {
            Flag flag = child.GetComponent<Flag>();
            flags[i] = flag;
            i++;
        }
        targetFlagIndex = 0;
        agent.SetDestination(flags[targetFlagIndex].GetPosition());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!agent) { return; }
        targetFlagIndex++;
        targetFlagIndex = targetFlagIndex%flags.Length;
        agent.SetDestination(flags[targetFlagIndex].GetPosition());
    }


}
