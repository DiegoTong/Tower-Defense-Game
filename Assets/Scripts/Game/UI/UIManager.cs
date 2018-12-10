using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform enemyHealthBars;
    public GameObject addTowerWindow;
    public GameObject towerInfoWindow;
    public GameObject winGameWindow;
    public GameObject loseGameWindow;
    public GameObject centerWindow;
    public GameObject damageCanvas;
    public GameObject blackBackground;
    public Text txtGold;
    public Text txtWave;
    public Text txtEscapedEnemies;
    public GameObject enemyHealthBarPrefab;
    void Awake()
    {
        Instance = this;
    }
    private void UpdateTopBar()
    {
        txtGold.text = GameManager.Instance.gold.ToString();
        txtWave.text = "Wave " + GameManager.Instance.waveNumber + " / " + WaveManager.Instance.enemyWaves.Count;
        txtEscapedEnemies.text = "Escaped Enemies " + GameManager.Instance.escapedEnemies
                                ;
    }
    public void ShowAddTowerWindow(GameObject towerSlot)
    {
        addTowerWindow.SetActive(true);
        addTowerWindow.GetComponent<AddTowerWindow>().towerSlotToAddTowerTo = towerSlot;

        UtilityMethods.MoveUiElementToWorldPosition(addTowerWindow.GetComponent<RectTransform>(), towerSlot.transform.position);
    }
    void Update()
    {
        UpdateTopBar();
    }
    public void ShowTowerInfoWindow(Tower tower)
    {
        towerInfoWindow.GetComponent<TowerInfoWIndow>().tower = tower;
        towerInfoWindow.SetActive(true);

        UtilityMethods.MoveUiElementToWorldPosition(towerInfoWindow.GetComponent<RectTransform>(), tower.transform.position);
    }
}
