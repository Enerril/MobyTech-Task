using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNavGraph : MonoBehaviour
{
    IAstarAI ai;
    ProceduralGridMover gridMover;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        gridMover = GetComponent<ProceduralGridMover>();    
    }

    // Update is called once per frame
    void Update()
    {
        gridMover.UpdateGraph();
    }
}
