using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    // i don't need fsm for now right?..

    [SerializeField ]LevelManager levelManager;

    [SerializeField] Transform _lastPassedTransform;
    [SerializeField] float moveSpeed=2f; 
    public EventHandler OnPassedEndpoint;
    [SerializeField]Vector3 _coverPoint;

    public Vector3 CoverPoint { get { return _coverPoint; } set { _coverPoint = value; } }


    bool _isSnapped;
    bool _isCovered;
    
    bool _onPosition;
    bool _onTheMove;



    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // OnPassedEndpoint += lala;

        _coverPoint = levelManager.GetCoverPosition();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, _coverPoint) < 0.1f && !_onPosition)
        {
            // have level manager subscribe and spawn another level, then feed back patrol point.
            OnPassedEndpoint?.Invoke(this, EventArgs.Empty);
            _onPosition = true;
        }


        if (!_onPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _coverPoint, moveSpeed * Time.deltaTime);
        }

    }


   
}
