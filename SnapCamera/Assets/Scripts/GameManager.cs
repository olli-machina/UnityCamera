using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMove;
    public CameraScript camScript;
    public BrokemonManager.PhotoData[] photoCollection;

    public BrokemonManager pokemonManager;

    public Text photoName, photoScore;

    public bool reviewScreen = false;
    public int photoIndex = 0;

    public int reviewIndex = 0;

    private int overallScore;

    [SerializeField] private Image reviewPhotoArea;
    [SerializeField] private GameObject reviewPhotoFrame;
    [SerializeField] private TextMeshProUGUI reviewPhotoName, reviewPhotoScore;

    // Start is called before the first frame update
    void Start()
    {
        photoCollection = new BrokemonManager.PhotoData[camScript.photoCount];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecordPhotoData(Texture2D photo)
    {
        if (playerMove.pokemonInPhoto)
        {
            float angle = playerMove.getAngle();
            string name = playerMove.photoPokemon.name;
            BrokemonManager.PhotoData newPhoto = new BrokemonManager.PhotoData
            (name, photo, angle);

            photoCollection[photoIndex] = newPhoto;
        }
        else
        {
            BrokemonManager.PhotoData newPhoto = new BrokemonManager.PhotoData
            ( "none", photo, 0f);

            photoCollection[photoIndex] = newPhoto;
        }
        photoIndex++;
    }

    public void NextPhoto()
    {
        if (reviewIndex < photoCollection.Length)
        {
            Texture2D currentPhoto = photoCollection[reviewIndex].photo;
            camScript.ShowPhoto(currentPhoto);
            reviewPhotoName.text = photoCollection[reviewIndex].name;
            //int score = (int)photoCollection[reviewIndex].angle;
            int score = Mathf.Abs(500 - ((int)photoCollection[reviewIndex].angle)*10);
            reviewPhotoScore.text = score.ToString();
        }
    }
}
