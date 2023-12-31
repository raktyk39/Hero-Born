using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities 
{
   public static int playerDeaths = 0;
   
   public static string UpdateDeathCount(ref int countReference)
   {
      countReference += 1;
      return "Next time youll be at number " + countReference;
   }

   public static void RestartLevel()
   {
      SceneManager.LoadScene(0);
      Time.timeScale = 1.0f;
        
      Debug.Log("Player deaths: " + playerDeaths);
      string message = UpdateDeathCount(ref playerDeaths);
      Debug.Log("Player deaths: " + playerDeaths);
   }

   public static bool RestartLevel(int sceneIndex)
   {
      SceneManager.LoadScene(sceneIndex);
      Time.timeScale = 1.0f;
      return true;
   }

  


//Иногда в программе нужны переменные, в которых бы хранились постоянные и неизменяемые значения. Добавление к переменной ключевого слова const после модификатора доступа позволяет реализовать
// именно это, но только для встроенных типов C#. Например, значение
// переменной maxItems в классе GameBehavior стоило бы сделать постоянным:
// public const int maxItems = 4; 
// 322 Глава 10 • ǹнова о типах, методах и классах
// Проблема работы с постоянными переменными заключается в том, что
// значение им можно присвоить только в момент объявления, то есть мы
// не можем задать maxItems без начального значения

// public readonly int maxItems; 
// Использование ключевого слова readonly для объявления переменной
// даст нам то же неизменяемое значение, что и константа, но при этом
// позволит присвоить ее начальное значение в любое время
}
