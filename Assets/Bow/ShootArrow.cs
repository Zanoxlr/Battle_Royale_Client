using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject Arrow;
    public Camera camera;
    GameObject clone;
    public float timer = 0;
    bool canShoot = true;
    public Transform topBow;
    public Transform bottomBow;
    Vector3 arrowPosBow;
    public Color lineColor;

    void OnDrawGizmos()
    {
        //Line draw
        Gizmos.color = lineColor;
        if (clone != null && timer > 0)
        {
            Gizmos.DrawLine(topBow.position, clone.transform.position);
            Gizmos.DrawLine(clone.transform.position, bottomBow.position);
        }
        else
        {
            Gizmos.DrawLine(topBow.position, bottomBow.position);
        }
    }
    void Update()
    {
        //Geting inputs
        if (Input.GetAxis("RightClick") == 1 && canShoot == true)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            clone = Instantiate(Arrow);
            clone.transform.parent = Arrow.transform.parent;
            clone.transform.localPosition = new Vector3(0.5f, -0.2f, 1.2f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ArrowLaunch());
        }
        //Change fov of camera and get the arrow back
        if (timer < 3 && timer > 0.5f)
        {
            clone.transform.localPosition = new Vector3(0.44f, -0.2f, clone.transform.localPosition.z - 0.4f * Time.deltaTime);
            clone.transform.localRotation = Quaternion.Euler(0, -19, 0);
            camera.fieldOfView += 8.75f * Time.deltaTime;
        }
        else if (camera.fieldOfView > 90)
        {
            StartCoroutine(ArrowLaunch());
            camera.fieldOfView -= 200 * Time.deltaTime;
        }
        //Zoom
        if (Input.GetKey(KeyCode.LeftControl))
        {
            camera.fieldOfView = 40;
        }
        else if (camera.fieldOfView < 90)
        {
            camera.fieldOfView += 200 * Time.deltaTime;
        }
    }
    IEnumerator ArrowLaunch()
    {
        canShoot = false;
        clone.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 20;
        clone.GetComponent<Rigidbody>().isKinematic = false;
        clone.transform.parent = null;
        timer = 0;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
