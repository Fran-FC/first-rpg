using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    public GameObject ammoPrefab;
    static List<GameObject> ammoPool;
    public int poolSize;
    public float weaponVelocity;

    // for shooting animnation
    [HideInInspector]
    public Animator animator;
    Camera localCamera;
    bool shooting = false;
    enum Quadrant
    {
        East, South, West, North
    }

    private void Start() {
        animator = GetComponent<Animator>();
        shooting = false;
        localCamera = Camera.main;
    }
    void Awake() {
        if (ammoPool == null) {
            ammoPool = new List<GameObject>();
        }
        for (int i = 0; i < poolSize; i++) {
            GameObject ammoObject = Instantiate(ammoPrefab);
            ammoObject.SetActive(false);
            ammoPool.Add(ammoObject);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            shooting = true;
            FireAmmo();
        } else {
            shooting = false;
        }
        UpdateState();
    }
    private void UpdateState() {
        if(shooting)
        {
            Vector2 quadrantVector = Vector2.zero;
            switch(GetQuadrant())
            {
                case Quadrant.East:
                    quadrantVector.x = 1.0f;
                    break;
                case Quadrant.West:
                    quadrantVector.x = -1.0f;
                    break;
                case Quadrant.North:
                    quadrantVector.y = 1.0f;
                    break;
                case Quadrant.South:
                    quadrantVector.y = -1.0f;
                    break;
            }
            animator.SetFloat("fireXDir", quadrantVector.x);
            animator.SetFloat("fireYDir", quadrantVector.y);

            Debug.Log(quadrantVector);
        }
        animator.SetBool("isFiring", shooting);
    }

    private Quadrant GetQuadrant(){
        Vector2 mousePosition = localCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = transform.position;
        Vector2 localDir = mousePosition - playerPosition;
        if (localDir.x > localDir.y)
            if (localDir.x > -localDir.y)
                return Quadrant.East;
            else
                return Quadrant.South;
        else
            if (localDir.x < -localDir.y)
                return Quadrant.West;
            else
                return Quadrant.North;
    }

    GameObject SpawnAmmo(Vector3 location) {
        foreach (GameObject ammo in ammoPool) {
            if (ammo.activeSelf == false) {
                ammo.SetActive(true);
                ammo.transform.position = location;
                return ammo;
            }
        }
        return null;
    }

    void FireAmmo() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject ammo = SpawnAmmo(transform.position);

        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            float travelDuration = 1.0f / weaponVelocity;
            StartCoroutine(arcScript.TravelArc(mousePosition, travelDuration));
        }
    }

    private void OnDestroy() {
        ammoPool = null;
    }
}
