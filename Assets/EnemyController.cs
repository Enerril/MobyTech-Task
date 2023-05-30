using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    bool goPatrol=true;
    bool waiting;
    int direction;
    public LevelManager LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(1f);
        goPatrol = false;
        direction =direction==1?-1:1;
        StartCoroutine(PatrolStart());

    }

    IEnumerator PatrolStart()
    {
        yield return new WaitForSeconds(1f); // lazy to cache...

        goPatrol =true;
        StartCoroutine(ChangeDirection());
    }




    // Update is called once per frame
    void Update()
    {
        if (goPatrol)
        {
            transform.position+=transform.right*moveSpeed*Time.deltaTime*direction;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        LevelManager.EnemyKilled();
    }

}
