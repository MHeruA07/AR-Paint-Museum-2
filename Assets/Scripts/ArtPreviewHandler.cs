using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ArtPreviewHandler : MonoBehaviour
{
    public static ArtPreviewHandler instance;
    public Sprite[] artList1;
    public Sprite[] artList2;
    public Sprite[] artList3;
    public Sprite[] artList4;
    public Sprite[] artList5;
    public Sprite[] artList6;
    public Sprite[] artList7;
    public Sprite[] artList8;
    public Sprite[] artList9;
    public Sprite[] artList10;
    public Sprite[] artList11;
    public Sprite[] artList12;
    public Sprite[] artList13;
    public Sprite[] artList14;
    public Sprite[] artList15;
    public Sprite[] artList16;
    public Sprite[] artList17;
    public Sprite[] artList18;
    public Sprite[] artList19;
    public Sprite[] artList20;
    public SpriteRenderer[] artSpriteRendererList;
    public GameObject bioPanel;
    public GameObject artListPanel;
    public Transform bioButtonTrf;
    public Image bioPhoto;
    public Text bioText;
    public SpriteRenderer artSpriteRenderer;
    public GameObject scrollViewContent;

    public int idMarker;

    private string dumbObjectName;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowArtPreviewPanel(){
        artListPanel.transform.DOScale(new Vector3(1,1,1), 0.3f);
    }

    public void HideArtPreviewPanel(){
        artListPanel.transform.DOScale(new Vector3(0,0,0), 0.3f);
    }

    public void ShowBioButton(){
        bioButtonTrf.DOScale(new Vector3(1,1,1), 0.3f);
    }

    public void HideBioButton(){
        bioButtonTrf.DOScale(new Vector3(0,0,0), 0.3f);
    }

    public void SeeBio(){
        bioPanel.SetActive(true);
    }

    public void CloseBio(){
        bioPanel.SetActive(false);
    }

    public void SetArtListPreview(int count, Sprite[] icon){
        for(int x=0; x<12; x++){
            if(x<count){
                scrollViewContent.transform.GetChild(x).GetComponent<Image>().sprite = icon[x];
                scrollViewContent.transform.GetChild(x).gameObject.SetActive(true);
            }else{
                scrollViewContent.transform.GetChild(x).gameObject.SetActive(false);
            }
        }
    }

    public void ChangeArtPreview(int id){
        dumbObjectName = "ImageTarget" + idMarker;
        switch(idMarker){
            case 1:
                artSpriteRendererList[idMarker - 1].sprite = artList1[id];
                if(id == 0){
                    GameObject.Find(dumbObjectName).transform.Find("3d paint frame").transform.Find("Paint Frame").gameObject.SetActive(false);
                }else{
                    GameObject.Find(dumbObjectName).transform.Find("3d paint frame").transform.Find("Paint Frame").gameObject.SetActive(true);
                }
                break;
            case 2:
                artSpriteRendererList[idMarker - 1].sprite = artList2[id];
                break;
            case 3:
                artSpriteRendererList[idMarker - 1].sprite = artList3[id];
                break;
            case 4:
                artSpriteRendererList[idMarker - 1].sprite = artList4[id];
                break;
            case 5:
                artSpriteRendererList[idMarker - 1].sprite = artList5[id];
                break;
            case 6:
                artSpriteRendererList[idMarker - 1].sprite = artList6[id];
                break;
            case 7:
                artSpriteRendererList[idMarker - 1].sprite = artList7[id];
                break;
            case 8:
                artSpriteRendererList[idMarker - 1].sprite = artList8[id];
                break;
            case 9:
                artSpriteRendererList[idMarker - 1].sprite = artList9[id];
                break;
            case 10:
                artSpriteRendererList[idMarker - 1].sprite = artList10[id];
                break;
            case 11:
                artSpriteRendererList[idMarker - 1].sprite = artList11[id];
                break;
            case 12:
                artSpriteRendererList[idMarker - 1].sprite = artList12[id];
                break;
            case 13:
                artSpriteRendererList[idMarker - 1].sprite = artList13[id];
                break;
            case 14:
                artSpriteRendererList[idMarker - 1].sprite = artList14[id];
                break;
            case 15:
                artSpriteRendererList[idMarker - 1].sprite = artList15[id];
                break;
            case 16:
                artSpriteRendererList[idMarker - 1].sprite = artList16[id];
                break;
            case 17:
                artSpriteRendererList[idMarker - 1].sprite = artList17[id];
                break;
            case 18:
                artSpriteRendererList[idMarker - 1].sprite = artList18[id];
                break;
            case 19:
                artSpriteRendererList[idMarker - 1].sprite = artList19[id];
                break;
            case 20:
                artSpriteRendererList[idMarker - 1].sprite = artList20[id];
                break;
        }
        GameObject.Find(dumbObjectName).GetComponent<TargetImageTracker>().artId = id;
    }
}
