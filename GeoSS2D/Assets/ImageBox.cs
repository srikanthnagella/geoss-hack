using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


using SimpleJSON;

public class ImageBox : MonoBehaviour
{
    private WWW www;
    private IEnumerator ImageEnumerator;
    private int ImageType = 0;
    int index = 1;

    int ShootType = 5;
    public string[] ImageTypes = new string[]{
        "Opaque Cloud",
        "Thin Cloud",
        "ThickCloud",
        "Water",
        "Land",
        "Snow",
    };
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        // Check the score 
        ScoreManager scoreText = GameObject.Find("ScoreManager").GetComponent("ScoreManager") as ScoreManager;
        scoreText.increaseScore(1);
        // Get the next image
        GetRandomImage();
    }

    void GetRandomImage()
    {
        Debug.Log("Calline new Image");
        //  string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png";
        index++;
        ImageEnumerator = LoadImageTex(index);
        StartCoroutine(ImageEnumerator);
    }

    IEnumerator LoadImageTex(int indx)
    {
        string url = "http://127.0.0.1:8000/getImage/" + indx + "/";
        Debug.Log("Calling new texture");
        Texture2D tex;
        tex = new Texture2D(128, 128, TextureFormat.DXT5, false);
        using (www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            GetComponent<MeshRenderer>().material.mainTexture = tex;
        }
        string scoreurl = "http://127.0.0.1:8000/getScore/" + indx + "/";
        using (www = new WWW(scoreurl))
        {
            yield return www;
            Debug.Log(www.text);
            var N = JSON.Parse(www.text);
            if (float.Parse(N["land"].Value) >= 1)
            {
                ImageType = 5;
            }
            if (float.Parse(N["opaqueCloud"].Value) >= 1)
            {
                ImageType = 1;
            }
            if (float.Parse(N["thinCloud"].Value) >= 1)
            {
                ImageType = 2;
            }
            if (float.Parse(N["thickCloud"].Value) >= 1)
            {
                ImageType = 3;
            }
            if (float.Parse(N["water"].Value) >= 1)
            {
                ImageType = 4;
            }
            if (float.Parse(N["snow"].Value) >= 1)
            {
                ImageType = 6;
            }
            Debug.Log(ImageType);
        }
    }
}
