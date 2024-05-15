
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour,IManager
{ 
  [SerializeField]
  private int _itemCollected;
  private string _state;
  public string  labelText = "Collect all 4 items and win your freedom! ";
  public int maxItem = 4;
  public bool showWinScreen;
  public bool showLossScreen;

  public string State
  {
    get { return _state;}
    set { _state = value;}
  }

  void Start()
  {
    Intialize();
  }

   public void Intialize()
  {
    _state = "Manger intialized..";
    Debug.Log(_state);
  }

  public int Items
  {
    get { return _itemCollected; }
    set
    {
        _itemCollected = value;

        if (_itemCollected >= maxItem) 
        {
          Time.timeScale = 0f;

          labelText = "You've found all the items !";

          showWinScreen = true;
        }
        else 
        {
          labelText = "Item found, only" + (maxItem - _itemCollected) + "more to go!";
        }
    }
  }

  private int _playerHP = 10;
  public int HP
  {
    get { return _playerHP; }
    set
    {
        _playerHP = value;
        Debug.LogFormat("HP: {0}", _playerHP);

        if(_playerHP <= 0)
        {
          labelText = "You want another life with that?";
          showLossScreen = true;
          Time.timeScale = 0f;
        }
        else
        {
          labelText = "Ouch... that’s got hurt.";
        }
    }
  }

  void OnGUI () 
  {

      GUI.Box(new Rect (20,20,150,25), // 20 - x Точка от старта, 20 - y Точка от старта;150 - Ширинаб, 25 - Высота
      "Player Health:" + _playerHP );

      GUI.Box ( new Rect (20,50,150,25),
      "Items Collected:" + _itemCollected);

      GUI.Label ( new Rect (Screen.width / 2 - 100,  Screen.height - 50,300,50), labelText);

    if (showWinScreen) // В условиях по умолчанию true
    {
        if (GUI.Button(new Rect (Screen.width/2 - 100, Screen.height/2 - 50, 200,100), "You WON!"))  // Если кнопка нажата то пройсходит...
        {
          Utilities.RestartLevel(0);
        }
    }

    if(showLossScreen)
    {
      if(GUI.Button(new Rect(Screen.width / 2 - 100,
        Screen.height / 2 - 50, 200,100), "You lose..."))
      {
        Utilities.RestartLevel();
      }
    }
  }
}
