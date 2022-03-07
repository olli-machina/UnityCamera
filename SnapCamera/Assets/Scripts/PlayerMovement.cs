using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int maxRadius, maxAngle, maxHeightLimit;
    public float moveSpeed, moveDist;
    public Transform[] inRangePokemon;

    private float timeMoved;
    private Vector3 startPoint, endPoint;

    // Start is called before the first frame update
    void Start()
    {
        inRangePokemon = null;
        startPoint = transform.position;
        endPoint = transform.position + (Vector3.forward * moveDist);
    }

    // Update is called once per frame
    void Update()
    {
         inRangePokemon = inFOV(transform, maxRadius, maxAngle);
        
        transform.position = Vector3.Lerp(startPoint, endPoint, timeMoved / moveSpeed);
        if (timeMoved >= moveSpeed)
        {
            Vector3 temp = endPoint;
            endPoint = startPoint;
            startPoint = temp;
            timeMoved = 0f;
        }
        else
            timeMoved += Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; //draw max distance photo can be taken from
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;
        Gizmos.color = Color.blue; //both right and left FOV bounds
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2); 
        
        Vector3 UpperLimit = Quaternion.AngleAxis(maxHeightLimit, transform.right) * transform.forward * maxRadius; //we will see if upper/lower bounds worth it
        Vector3 LowerLimit = Quaternion.AngleAxis(-maxHeightLimit, transform.right) * transform.forward * maxRadius;
        Gizmos.color = Color.blue; //both upper and lower FOV bounds
        Gizmos.DrawRay(transform.position, UpperLimit);
        Gizmos.DrawRay(transform.position, LowerLimit);

        for (int i = 0; i < inRangePokemon.Length; i++)
        {
            if (inRangePokemon[i] != null)
            {
                Gizmos.color = Color.green; //ray to each pokemon seen
                Gizmos.DrawRay(transform.position, (inRangePokemon[i].position - transform.position).normalized * maxRadius);
            }
        }
        Gizmos.color = Color.black; //ray facing forward
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public static Transform[] inFOV(Transform checkingObj, float maxRadius, float maxAngle)
    {
        Collider[] overlaps = new Collider[10]; //everything in range
        int count = Physics.OverlapSphereNonAlloc(checkingObj.position, maxRadius, overlaps);
        Transform[] pokemon = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].tag == "Pokemon") //if there is a pokemon in range
                {
                    Transform temp = overlaps[i].transform;
                    Vector3 directionBetween = (temp.position - checkingObj.position).normalized;
                    directionBetween.y *= 0; //height not a factor

                    float angle = Vector3.Angle(checkingObj.forward, directionBetween);
                    if (angle <= maxAngle) //if in the FOV angle zone
                    {
                        Ray ray = new Ray(checkingObj.position, temp.position - checkingObj.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, maxRadius)) //if not behind something
                        {
                            if (hit.transform == temp) //if it's the target
                            {
                                //return temp;
                                pokemon[i] = temp;
                            }
                        }
                    }
                    
                }
            }
        }
        return pokemon;
    }
}
