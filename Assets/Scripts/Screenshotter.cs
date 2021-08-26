using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Screenshotter : MonoBehaviour
{
    //Name this whatever suits
    public string fileNamePre = "image";

    //FolderName
    public string folderName = "Screenshots";

    //Image Counter
    public int imgNumber = 0;

    //FilePath
    public string filePath = "Filepath needed";

    //Format
    public string format = "0000";

    //Call to the renderTexture method
    public RenderTexture renderTexture;

    //Screenshot Properties 
    public int renderTextureWidth = 500;
    public int renderTextureHeight = 500;

    void Start()
    {
        //Set timer for images to be screenshotted
        float start = 0.5f;
        float screenshotTimer = 0.5f;

        //method name to save the textures
        string methodName = "textureSaved";

        //constantly re-invoke the method
        InvokeRepeating(methodName, start, screenshotTimer);
    }

    private void Update()
    {
     if(Input.GetKeyDown(KeyCode.S))
        {
            textureSaved();
        }
    }

    public void textureSaved()
    {
        //Save the new data coming in as bytes
        byte[] bytes = toTexture2D(renderTexture).EncodeToPNG();

        string imageNumberString = imgNumber.ToString(format);
        string fileName = fileNamePre + imageNumberString + ".png";
        print("file name = " + fileName);

        // increament for next one
        imgNumber++;

        filePath = Path.Combine(Application.dataPath, folderName);
        filePath = Path.Combine(filePath, fileName);

        System.IO.File.WriteAllBytes(filePath, bytes);

    }

    Texture2D toTexture2D(RenderTexture texture)
    {
        //texture width
        float textureWidth = renderTexture.width;

        //New 2D Texture Created
        Texture2D newTex = new Texture2D(renderTextureWidth, renderTextureHeight, TextureFormat.RGB24, false);

        //Activate the texture
        RenderTexture.active = texture;

        //Allow it read pixels
        newTex.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        newTex.Apply();
        Destroy(newTex);
        return newTex;
    }
}
