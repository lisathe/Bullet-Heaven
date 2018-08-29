using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour {

    public static bool _autoFire;
    [SerializeField]
    private Text _autoFireText;
    private Canvas _canvas;
    private GameObject _mainMenuPanel;

    private void Awake()
    {
        //Grabs the autofire button(child of panel) and then the text (child of button)
        _autoFireText.text = "Auto fire: " + _autoFire;
        _canvas = FindObjectOfType<Canvas>();
    }
    private void Start()
    {
        _mainMenuPanel = _canvas.transform.GetChild(0).gameObject;
    }

    public void ChangeAutoFire()
    {
        _autoFire = !_autoFire;
        _autoFireText.text = "Auto fire: " + _autoFire;
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
