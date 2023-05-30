using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 _offset;
    [SerializeField] Transform _lookAtTransform;
    [SerializeField] Vector3 _lookAtPosition;
    [SerializeField] float cameraSpeed=2f;

    [SerializeField] LevelManager levelManager;
    [SerializeField] PlayerController playerController;

    public Vector3 Offset { get { return _offset; } set { _offset = value; } }

    public Transform LookAtTransform { get { return _lookAtTransform; } set { _lookAtTransform = value; } }
    public Vector3 LookAtPosition { get { return _lookAtPosition; } set { _lookAtPosition = value; } }

    float _currentSpeed;
    public float CurrentSpeed { get { return _currentSpeed; } set { _currentSpeed = value; } }  
    // Start is called before the first frame update
    void Start()
    {
        _lookAtTransform = player;

        _lookAtPosition = player.transform.position;

        playerController.OnReachedCoverPos+=LookAtLevel;
        levelManager.OnLevelCompleted += LookAtPlayer;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var curPos = player.transform.position+_offset;
        _currentSpeed = cameraSpeed * Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(transform.position + _offset, curPos, _currentSpeed);


        //transform.LookAt(LookAtTransform);
    }

    void LookAtLevel(object o, EventArgs e)
    {
        _offset = new Vector3(0, -.1f, .15f);
    }

    void LookAtPlayer(object o, EventArgs e)
    {
        _offset = new Vector3(0, 0,-0.05f);
    }

    private void OnDisable()
    {
        playerController.OnReachedCoverPos -= LookAtLevel;
        levelManager.OnLevelCompleted -= LookAtPlayer;
    }
}
