using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    // i don't need fsm for now right?.. nor scale with screen size...

    [SerializeField ]LevelManager levelManager;
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _lastPassedTransform;
    [SerializeField] float _moveSpeed=2f; 
    Camera _camera;
    public event EventHandler OnPassedEndpoint;
    public event EventHandler OnReachedCoverPos;
    [SerializeField]Vector3 _coverPoint;

    public Vector3 CoverPoint { get { return _coverPoint; } set { _coverPoint = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    bool _isSnapped;
    bool _isCovered;
    
    bool _onPosition;
    bool _onTheMove;

    GameObject proj;

    private void Awake()
    {
        //
    }

    // Start is called before the first frame update
    void Start()
    {
        // OnPassedEndpoint += lala;
        _camera = Camera.main;
        _coverPoint = levelManager.GetCoverPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, _coverPoint) < 0.1f && !_onPosition)
        {
            // have level manager subscribe and spawn another level, then feed back patrol point.
            OnReachedCoverPos?.Invoke(this, EventArgs.Empty);
            _onPosition = true;
        }


        if (!_onPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _coverPoint, _moveSpeed * Time.deltaTime);
        }






    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos=new Vector3();
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                pos = raycastHit.point;
                proj = Instantiate(_projectile, transform.position, Quaternion.identity);
                proj.transform.LookAt(pos);
            }

                      
        }
    }


}
