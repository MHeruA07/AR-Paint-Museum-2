using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ArtPreviewHandler : MonoBehaviour
{
    public static ArtPreviewHandler instance;
    public GameObject artListPanel;
    public GameObject scrollViewContent;
    public Transform exitButton;
    public Transform bioButtonTrf;
    public Transform bioPanel;
    public Image bioPhoto;
    public Image bioTransparent;
    public Text bioText;

    public int idMarker;
    public string spriteName;

    private string dumbObjectName;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }

        InstantiateFrame();
        exitButton.DOScale(new Vector3(1,1,1), 0.3f);
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
        StartCoroutine(WaitSeeBio());
    }

    public void CloseBio(){
        StartCoroutine(WaitCloseBio());
    }

    private IEnumerator WaitSeeBio(){
        bioPanel.DOScale(new Vector3(1,1,1), 0.3f);
        yield return new WaitForSeconds(0.2f);
        bioTransparent.enabled = true;
    }

    private IEnumerator WaitCloseBio(){
        bioTransparent.enabled = false;
        bioPanel.DOScale(new Vector3(0,0,0), 0.3f);
        yield return null;
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
        spriteName = GameObject.Find(dumbObjectName).GetComponent<TargetImageTracker>().paintList[id].name;

        if(spriteName.Contains("pf1")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(true);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(false);
        }else if(spriteName.Contains("lf1")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(true);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(false);
        }else if(spriteName.Contains("rf1")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(true);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(false);
        }else if(spriteName.Contains("pf2")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(true);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(false);
        }else if(spriteName.Contains("lf2")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(true);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(false);
        }else if(spriteName.Contains("rf2")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(true);
        }else if(spriteName.Contains("n")){
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.001").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.002").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.003").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.101").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.102").gameObject.SetActive(false);
            GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Frame.103").gameObject.SetActive(false);
        }

        GameObject.Find(dumbObjectName).transform.Find("3d frame").transform.Find("Paint Image").GetComponent<SpriteRenderer>().sprite = GameObject.Find(dumbObjectName).GetComponent<TargetImageTracker>().paintList[id];
        GameObject.Find(dumbObjectName).GetComponent<TargetImageTracker>().artId = id;
    }

    private void InstantiateFrame(){
        GameObject paintFrame;

        for(int x=1 ; x<=20 ; x++){
            paintFrame = Instantiate(Resources.Load("3d frame")) as GameObject;
            paintFrame.name = "3d frame";
            paintFrame.transform.parent = GameObject.Find("ImageTarget" + x).transform;
            paintFrame.transform.localPosition = new Vector3(0,0,0);
            paintFrame.transform.localRotation = Quaternion.Euler(0,-90,-90);
            paintFrame.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
            paintFrame = null;
        }
    }

    public void ExitApp(){
        Application.Quit();
    }
}
