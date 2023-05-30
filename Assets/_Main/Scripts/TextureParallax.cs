using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextureParallax : MonoBehaviour
{
    [SerializeField] RawImage _rawImage;
    [SerializeField] CameraFollower _cameraFollower;
    [SerializeField] float horizontalSpeed=0f, verticalSpeed=0f;
    [SerializeField] float mult=1f;
    float parallaxSpeed;

    // Update is called once per frame
    void Update()
    {
        parallaxSpeed = _cameraFollower.CurrentSpeed *(1+ horizontalSpeed);
        Vector2 newPos = new Vector2(parallaxSpeed, verticalSpeed) * mult * Time.deltaTime;
        _rawImage.uvRect = new Rect(_rawImage.uvRect.position + newPos,_rawImage.uvRect.size);
        
    }
}
