using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PlayerController playerController;
    GroundGenerator groundGenerator;
    [SerializeField] LevelData currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector3 GetCoverPosition()
    {
        Debug.Log("MANAGER " + currentLevel.CoverPoint);
        return currentLevel.CoverPoint;
    }

}
