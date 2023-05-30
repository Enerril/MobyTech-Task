using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projController : MonoBehaviour
{
    [SerializeField] float projSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * projSpeed * Time.deltaTime;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
