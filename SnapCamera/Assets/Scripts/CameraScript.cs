using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraScript : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private TextMeshProUGUI counterText;

    private Texture2D screenCapture;
    private bool photoVisible;
    private float photoTimer;
    public bool outOfFilm = false;

    public List<Texture2D> savedPhotos;
    public int photoCount = 10;
    public float photoDisplayTime;

    private GameManager gameManager;
    public Camera main, aim;


    // Start is called before the first frame update
    void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        counterText.SetText(photoCount.ToString());
        photoTimer = photoDisplayTime;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!outOfFilm)
            {
                if (photoVisible)
                {
                    photoVisible = false;
                    photoFrame.SetActive(false);
                }

                StartCoroutine(CapturePhoto());
                photoCount--;
                counterText.SetText(photoCount.ToString());
                photoTimer = photoDisplayTime;
                gameManager.AddToList();
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            aim.gameObject.SetActive(true);
            main.gameObject.SetActive(false);
        }
        if(Input.GetMouseButtonUp(1))
        {
            aim.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
        }

        if(photoVisible)
        {
            photoTimer -= Time.deltaTime;
            if(photoTimer <= 0f)
            {
                RemovePhoto();
            }
        }

        IEnumerator CapturePhoto()
        {
            cameraUI.SetActive(false);
            photoVisible = true;

            yield return new WaitForEndOfFrame();

            Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

            screenCapture.ReadPixels(regionToRead, 0, 0, false);
            screenCapture.Apply();
            savedPhotos.Add(screenCapture);
            ShowPhoto(screenCapture);
            if (photoCount > 0)
            {
                cameraUI.SetActive(true);
            }
            else
            {
                outOfFilm = true;
                gameManager.CollectPhotos(savedPhotos);
            }
        }


    }
    public void ShowPhoto(Texture2D photo)
    {
        Sprite photoSprite = Sprite.Create(photo, new Rect(0.0f, 0.0f, photo.width, photo.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
    }

    void RemovePhoto()
    {
        photoVisible = false;
        photoFrame.SetActive(false);
    }
}
