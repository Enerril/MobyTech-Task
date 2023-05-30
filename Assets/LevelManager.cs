using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelManager : MonoBehaviour
{
    [SerializeField]PlayerController playerController;
    GroundGenerator groundGenerator;
    [SerializeField] LevelData[] levels;
    [SerializeField] LevelData currentLevel;
    [SerializeField] EnemyController enemyController; 
    public event EventHandler OnResolutionChanged;
    public event EventHandler OnLevelCompleted;
    public Transform CameraLookPos;
    int enemyCount;
    int enemyKilledCount;
    bool levelInitialized;

    // Start is called before the first frame update
    void Start()
    {
        playerController.OnReachedCoverPos += LoadEnemies; // spawn enemies, change camera pos, stop player, spawn next level // reached first time on the level != after shooting. need separate bool
    }

   


    public Vector3 GetCoverPosition()
    {
        //Debug.Log("MANAGER " + currentLevel.CoverPoint);
        return currentLevel.CoverPoint;
    }

    void LoadEnemies(object o,EventArgs e)
    {
        if (!levelInitialized)
        {
            enemyCount = UnityEngine.Random.Range(1, currentLevel.enemySpawnPoints.Length); // random amount of enemies.
            Debug.Log(enemyCount);
            for (int i = 0; i < enemyCount; i++)
            {
               // Debug.Log("HERE25");

                var g=Instantiate(enemyController,currentLevel.enemySpawnPoints[i].position,Quaternion.identity);
                g.LevelManager = this;
            }
            



            levelInitialized = true;
        }
    }

    void LevelCleared()
    {
        var p = UnityEngine.Random.Range(0, levels.Length);

        var newlvldata= Instantiate(levels[p], currentLevel.EndPoint.position+new Vector3(10,0,0), Quaternion.identity);

        currentLevel=newlvldata;
        CameraLookPos = newlvldata.CameraLookPos;
        StartCoroutine(ResetBools());

        OnLevelCompleted?.Invoke(this,EventArgs.Empty);
    }

    IEnumerator ResetBools()
    {
        yield return new WaitForSeconds(1f);
        levelInitialized = false;
        enemyKilledCount = 0;
    }

    private void OnDisable()
    {
        playerController.OnReachedCoverPos -= LoadEnemies;
    }

    public void EnemyKilled()
    {
        enemyKilledCount++;
        if (enemyKilledCount >= enemyCount)
        {
            LevelCleared();
            enemyKilledCount = 0;
        }
    }
}
