using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCharacterCustomizer : MonoBehaviour
{
    public int textureNum = 0;
    public Material[] skins;
    public SkinnedMeshRenderer playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        SetSkinTexture(PlayerPrefs.GetInt("Skin"));
    }

    public void NextHatLocal()
    {

    }

    public void SetSkinTexture(int skinIndex)
    {
        textureNum = skinIndex;
        playerMesh.material = skins[textureNum];

        PlayerPrefs.SetInt("Skin", textureNum);
    }

    public void NextSkinLocal()
    {
        int nextTexture = textureNum + 1;
        if (nextTexture >= skins.Length) nextTexture = 0;
        textureNum = nextTexture;

        playerMesh.material = skins[textureNum];

        PlayerPrefs.SetInt("Skin", textureNum);
    }
}
