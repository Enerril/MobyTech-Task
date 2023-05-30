using UnityEngine;
using System;
/// <summary>
/// Responsive Camera Scaler
/// </summary>
public class CameraAspectRatioScaler : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    /// <summary>
    /// Reference Resolution like 1920x1080
    /// </summary>
    public Vector2 ReferenceResolution;

    /// <summary>
    /// Zoom factor to fit different aspect ratios
    /// </summary>
    public Vector3 ZoomFactor = Vector3.one;

    /// <summary>
    /// Design time position
    /// </summary>
    [HideInInspector]
    public Vector3 OriginPosition;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
     //   Debug.Log("GOGO1");
        OriginPosition = transform.position;
     //   levelManager.OnResolutionChanged += UpdateCameraScale;
    }

    private void OnEnable()
    {
      //  Debug.Log("GOGO2");
        levelManager.OnResolutionChanged += UpdateCameraScale;
    }

    /// <summary>
    /// Update per Frame
    /// </summary>
    /*
    void Update()
    {

        if (ReferenceResolution.y == 0 || ReferenceResolution.x == 0)
            return;

        var refRatio = ReferenceResolution.x / ReferenceResolution.y;
        var ratio = (float)Screen.width / (float)Screen.height;

        transform.position = OriginPosition + transform.forward * (1f - refRatio / ratio) * ZoomFactor.z
                                            + transform.right * (1f - refRatio / ratio) * ZoomFactor.x
                                            + transform.up * (1f - refRatio / ratio) * ZoomFactor.y;


    }
    */

    public void UpdateCameraScale(object o, EventArgs e)
    {
        if (ReferenceResolution.y == 0 || ReferenceResolution.x == 0)
            return;

        var refRatio = ReferenceResolution.x / ReferenceResolution.y;
        var ratio = (float)Screen.width / (float)Screen.height;

        transform.position = OriginPosition + transform.forward * (1f - refRatio / ratio) * ZoomFactor.z
                                            + transform.right * (1f - refRatio / ratio) * ZoomFactor.x
                                            + transform.up * (1f - refRatio / ratio) * ZoomFactor.y;
    }

    private void OnDisable()
    {
        levelManager.OnResolutionChanged -= UpdateCameraScale;
    }
}