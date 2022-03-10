using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMove;
    public CameraScript camScript;
    public PokemonManager.PhotoData[] photoCollection;

    public Text photoName, photoScore;
    public bool reviewScreen = false;
    public int photoIndex = 0;
    public int reviewIndex = 0;

    [SerializeField] private Image reviewPhotoArea;
    [SerializeField] private GameObject reviewPhotoFrame;
    [SerializeField] private TextMeshProUGUI reviewPhotoName, reviewPhotoScore;

    // Start is called before the first frame update
    void Start()
    {
        photoCollection = new PokemonManager.PhotoData[camScript.photoCount];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RecordPhotoData(Texture2D photo)
    {
        if (playerMove.pokemonInPhoto)
        {
            float angle = playerMove.getAngle();
            string name = playerMove.photoPokemon.name;
            PokemonManager.PhotoData newPhoto = new PokemonManager.PhotoData
            (name, photo, angle);

            photoCollection[photoIndex] = newPhoto;
        }
        else
        {
            PokemonManager.PhotoData newPhoto = new PokemonManager.PhotoData
            ( "---", photo, playerMove.maxAngle);

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
            int score = (playerMove.maxAngle - Mathf.Abs(((int)photoCollection[reviewIndex].angle)))*10;
            reviewPhotoScore.text = score.ToString();
        }
    }
}
