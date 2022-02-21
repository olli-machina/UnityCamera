using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokemonScript : MonoBehaviour
{
    public Vector3 endLocation;
    private Vector3 startLocation;
    public float moveDuration = 2;
    public float timeElapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        startLocation = gameObject.transform.position;
        if(endLocation == new Vector3(0,0,0))
        {
            endLocation = gameObject.transform.position + (transform.forward * 10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed < moveDuration)
        {
            gameObject.transform.position = Vector3.Lerp(startLocation, endLocation, timeElapsed / moveDuration);
             
            timeElapsed += Time.deltaTime;
        }
        else
        {
            Vector3 temp = startLocation;
            startLocation = endLocation;
            endLocation = temp;
            gameObject.transform.rotation = Quaternion.Inverse(gameObject.transform.rotation);
            timeElapsed = 0;
        }
        
    }
}
