using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraUI;

    private Texture2D screenCapture;
    private bool photoVisible;


    // Start is called before the first frame update
    void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!photoVisible)
            {
                StartCoroutine(CapturePhoto());
            }
            else
            {
                RemovePhoto();
            }
            //take screenshot
        }

        IEnumerator CapturePhoto()
        {
            //camera ui set false
            cameraUI.SetActive(false);
            photoVisible = true;

            yield return new WaitForEndOfFrame();

            Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

            screenCapture.ReadPixels(regionToRead, 0, 0, false);
            screenCapture.Apply();
            ShowPhoto();
        }

        void ShowPhoto()
        {
            Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
            photoDisplayArea.sprite = photoSprite;

            photoFrame.SetActive(true);
        }

        void RemovePhoto()
        {
            photoVisible = false;
            photoFrame.SetActive(false);
            cameraUI.SetActive(true);
        }

    }
}
