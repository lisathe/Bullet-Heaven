using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private Canvas _canvas;
    private GameObject _options;
    private GameObject _shop;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
    }

    // Use this for initialization
    void Start()
    {
        _options = _canvas.transform.GetChild(1).gameObject;
        _shop = _canvas.transform.GetChild(2).gameObject;
    }

    public void GoToOptions()
    {
        gameObject.SetActive(false);
        _options.SetActive(true);
    }

    public void GoToShop()
    {
        gameObject.SetActive(false);
        _shop.SetActive(true);
    }

    public void Play()
    {
        // In case of pauses or performance issues, use Async.
        SceneManager.LoadScene("Endless Mode");
    }

}
