using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SeekerCharacterCustomizer : NetworkBehaviour
{
    [Networked(OnChanged = nameof(OnSkinMaterialChanged))]
    public int textureNum { get; set; } = 0;
    public Material[] skins;
    public SkinnedMeshRenderer playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        SetSkinTexture(PlayerPrefs.GetInt("skin"));
    }

    public void SetSkinTexture(int skinIndex)
    {
        textureNum = skinIndex;
        playerMesh.material = skins[textureNum];

        PlayerPrefs.SetInt("skin", textureNum);
    }

    public static void OnSkinMaterialChanged(Changed<SeekerCharacterCustomizer> changed)
    {
        changed.Behaviour.playerMesh.material = changed.Behaviour.skins[changed.Behaviour.textureNum];
    }
}
