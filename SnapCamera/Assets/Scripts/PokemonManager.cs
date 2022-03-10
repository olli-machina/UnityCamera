using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
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
}