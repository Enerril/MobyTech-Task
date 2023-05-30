using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelManager : MonoBehaviour
{
    [SerializeField]PlayerController playerController;
    GroundGenerator groundGenerator;
    [SerializeField] LevelData currentLevel;

    public event EventHandler OnResolutionChanged;


    // Start is called before the first frame update
    void Start()
    {
       // playerController.OnReachedCoverPos+= // spawn enemies, change camera pos, stop player, spawn next level
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
