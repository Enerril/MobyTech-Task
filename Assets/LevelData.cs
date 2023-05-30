using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    // each level has endpoint and coverPoint preset and camera look pos
    // also enemy spawnpoints.
    [field:SerializeField] public Transform EndPoint { get; private set; }
    [field: SerializeField] public Transform CameraLookPos { get; private set; }
    [field: SerializeField] public Transform[] enemySpawnPoints { get; private set; }
    [SerializeField] public GameObject coverGameobject;


    [field: SerializeField] public Vector3 CoverPoint{ get; private set; }
    
    private void Awake()
    {
        var l = coverGameobject.transform.position + new Vector3(0, 0, -.5f);
        //CoverPoint = transform.TransformPoint(CoverPoint);
        CoverPoint = l;
        Debug.Log("LEVELDATA " + CoverPoint);
    }


  
}
