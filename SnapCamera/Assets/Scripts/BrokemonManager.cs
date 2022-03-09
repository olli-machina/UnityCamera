using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokemonManager : MonoBehaviour
{
    public struct PhotoData
    {
        public string name;
        public Texture2D photo;
        public float angle;
        public PhotoData(string addName, Texture2D addPhoto, float addAngle)
        {
            this.name = addName;
            this.photo = addPhoto;
            this.angle = addAngle;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}