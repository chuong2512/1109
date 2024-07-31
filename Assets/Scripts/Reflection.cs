using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Reflection : MonoBehaviour
{
    public int relections;
    public float maxLength;
    public GameObject shootbutton;
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    public float necessaryTime = 1f;
    float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position,transform.forward);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for (int i = 0; i < relections; i++) {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag == "Enemy") {
                    elapsed += Time.fixedDeltaTime;
                    if (elapsed > necessaryTime)
                    {
                        GameManager.instance.ShootBtn.SetActive(true);
                        elapsed = 0;
                    }
                   
                      
                       
                    
                   
                }
                if (hit.collider.tag != "Mirror")
                    break;
               
            }

            else
            {

                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
            }
        }
    }


