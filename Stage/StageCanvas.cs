using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageCanvas : MonoBehaviour{

    [SerializeField]
    private Canvas stageButtonCanvas;
    
    [SerializeField]
    private StageSelectSceneManager sceneManager;

    [SerializeField]
    private Canvas stageCanvas;

    [SerializeField]
    private Text getStarText;
    
    [SerializeField]
    private string roundName;


    private StageButton[] stageButtons;
    private int getStar;
    private int maxStar;

    private void Start(){
        stageButtons = stageButtonCanvas?.GetComponentsInChildren<StageButton>();
        maxStar = stageButtons.Length;

        for(int i = 0; i < stageButtons.Length; i++){
            if(stageButtons[i].IsStar)
                getStar++;
        }


        getStarText.text = getStar.ToString() + " / " + maxStar.ToString();
    }

    public void OpenButtons(){
        stageCanvas.gameObject.SetActive(false);
        stageButtonCanvas.gameObject.SetActive(true);
    } 

    public void CloseButtons(){
        stageCanvas.gameObject.SetActive(true);
        stageButtonCanvas.gameObject.SetActive(false);
    }
    

    public void LoadScene(int nextStageNumber){
        GameManager.instance.nextRound = roundName;
        GameManager.instance.nextStageNumber = nextStageNumber;
        StartCoroutine(LoadSceneCoroutine());
    }

    public IEnumerator LoadSceneCoroutine(){
        yield return StartCoroutine(sceneManager.FadeIn());
        SceneManager.LoadScene("LoadingScene");   
    }
}