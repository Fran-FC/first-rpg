using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    private void Awake() {
        if(instance!= null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject vCam = GameObject.FindWithTag("VirtualCamera");
            virtualCamera = vCam.GetComponent<CinemachineVirtualCamera>();
        }
    }
}
