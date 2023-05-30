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
    bool _reachedCoverPointFirstTime;
    GameObject proj;
    float reloadTime;
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
        levelManager.OnLevelCompleted += ProceedToNextLevel;
    }

    private void ProceedToNextLevel(object sender, EventArgs e)
    {
        // change coverpoint
        StartCoroutine(ResetBools());
        _coverPoint = levelManager.GetCoverPosition();
    }

    IEnumerator ResetBools()
    {
        yield return new WaitForSeconds(.5f);
        _reachedCoverPointFirstTime = false;
        _onPosition = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, _coverPoint) < 0.1f && !_onPosition)
        {
            // have level manager subscribe and spawn another level, then feed back patrol point.
            if (!_reachedCoverPointFirstTime)
            {
                Debug.Log("PLAYER REACHED COVER");
                OnReachedCoverPos?.Invoke(this, EventArgs.Empty);

            }
                _onPosition = true;
            _reachedCoverPointFirstTime = true;
        }


        if (!_onPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _coverPoint, _moveSpeed * Time.deltaTime);
        }






    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && reloadTime>0.5f)
        {
            Vector3 pos=new Vector3();
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {

                if (_reachedCoverPointFirstTime)
                {
                    transform.position += new Vector3(1, 0, 0);
                    _onPosition = false;
                    pos = raycastHit.point;
                    proj = Instantiate(_projectile, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
                    proj.transform.LookAt(pos);
                    reloadTime = 0;
                }
                else
                {
                    
                    pos = raycastHit.point;
                    proj = Instantiate(_projectile, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
                    proj.transform.LookAt(pos);
                    reloadTime = 0;
                }



            }
          

                      
        }

        reloadTime += Time.deltaTime;
        if (reloadTime > 100) reloadTime = 0;
    }


}
