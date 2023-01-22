using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class pewPew : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 3000f;
    public double fireDelay = 1.0;
    private Vector3 mousePos;
    private double coolDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Unity Forum Go Crazy
        if (coolDown > 0){
            coolDown -= Time.deltaTime;
            if (coolDown < 0){
                coolDown = 0;
            }
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg-180;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        if (Input.GetMouseButton(0)&&coolDown==0)
        {
            shoot();
        }
    }

    private void shoot()
    {

        if (ReducePower(1) == true)
        {
            GameObject laser = Instantiate(projectile, transform.position, transform.rotation);
            laser.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -launchVelocity));

            Destroy(laser, 3f);
            coolDown += fireDelay;
        }
    }

    private bool ReducePower(int i)
    {
        return true;
    }
}