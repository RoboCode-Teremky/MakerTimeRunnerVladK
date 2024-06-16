using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] Panels;
    public GameObject FinishPanel;
    private GameObject LastPanel;
    public Transform Map;

    public void Generate(int PanelsCount){
        LastPanel = Instantiate(Panels[0] , Map);
        for (int i = 0; i < PanelsCount; i++)
            {
                LastPanel = Instantiate(Panels[Random.Range(0, Panels.Length)] , LastPanel.transform.Find("NextPanelGeneratorPoint").position , Quaternion.identity, Map);
            }
        Instantiate(FinishPanel, LastPanel.transform.Find("NextPanelGeneratorPoint").position , Quaternion.identity, Map);
    }

    void Start()
    {
        Random.InitState(PlayerPrefs.GetInt("PanelsNumber"));
        Generate(PlayerPrefs.GetInt("PanelsNumber")*5);
    }
}
