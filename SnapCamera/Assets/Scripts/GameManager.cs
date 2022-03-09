using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // public List<string> pokemonList;
   // public List<Texture2D> collectedPhotos;
    public PlayerMovement playerMove;
    public CameraScript camScript;
    public BrokemonManager.PhotoData[] photoCollection;

    public BrokemonManager pokemonManager;

    public Text photoName, photoScore;

    public bool reviewScreen = false;
    public int photoIndex = 0;

    private int overallScore;

    // Start is called before the first frame update
    void Start()
    {
        photoCollection = new BrokemonManager.PhotoData[camScript.photoCount];
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("c"))
        //{
        //    for (int i = 0; i < pokemonList.Count; i++)
        //    {
        //        if (pokemonList[i] != null)
        //        {
        //            Debug.Log("Added: " + pokemonList[i]);
        //        }
        //    }
        //}
    }

    public void RecordPhotoData(Texture2D photo)
    {
        if (playerMove.pokemonInPhoto)
        {
            BrokemonManager.PhotoData newPhoto = new BrokemonManager.PhotoData
            {
                photo = photo,
                angle = playerMove.getAngle(),
                name = playerMove.photoPokemon.name
            };

            photoCollection[photoIndex] = newPhoto;
        }
        else
        {
            BrokemonManager.PhotoData newPhoto = new BrokemonManager.PhotoData
            {
                photo = photo,
                angle = 0f,
                name = "none"
            };

            photoCollection[photoIndex] = newPhoto;
        }
        photoIndex++;
    }

    //public void AddToList()
    //{
    //    for (int i =0; i < playerMove.inRangePokemon.Length; i++)
    //    {
    //            if (playerMove.inRangePokemon[i] != null)
    //            {
    //                pokemonList.Add(playerMove.inRangePokemon[i].name);
    //                Debug.Log(playerMove.inRangePokemon[i].name);
    //            }
    //            else
    //                Debug.Log("nope");
    //       // }
    //    }
    //}

    //public void CollectPhotos(List<Texture2D> photos)
    //{
    //    playerMove.moveSpeed = 0f;
    //    collectedPhotos = photos;
    //    reviewScreen = true;
    //    //pokemonList.ToArray();
    //    camScript.ShowPhoto(collectedPhotos[0]);
    //}

    public void NextPhoto()
    {
        Debug.Log(photoCollection[1].name);

    }
}
