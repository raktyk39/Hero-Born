using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
     
  [SerializeField]
private int _itemCollected;

public string  labelText = "Collect all 4 items and win your freedom! ";

  public int maxItem = 4;

public int Items
{
    get { return _itemCollected; }
    set
    {1
        _itemCollected = value;
        Debug.LogFormat("Item: {0}", _itemCollected);
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
    }
}

}
