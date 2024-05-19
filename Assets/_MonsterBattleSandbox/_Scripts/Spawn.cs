using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
  [SerializeField] SpawnUnit    spawnUnit;
  [SerializeField] SpawnMonster spawnMonster;
  [SerializeField] Slider slider;

  private int spawnEnemyCount = 0;
  private int spawnDostCount  = 0;

    // Doldurma süresi (saniye)
    [SerializeField] public float düşmanGelmeSüresi;


 
    private void Awake()
    {
        // Slider'ın başlangıç değerini sıfır olarak ayarlayın
        slider.value = 0f;

        // Slider'ı doldurmaya başla
        StartCoroutine(FillSliderOverTime(düşmanGelmeSüresi));

    }

    IEnumerator FillSliderOverTime(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Geçen zamana göre slider değerini hesapla
            slider.value = elapsedTime / duration;

            // Zamanı artır
            elapsedTime += Time.deltaTime;

            // Bir sonraki frame'e kadar bekle
            yield return null;
        }

        // Süre dolduğunda slider'ı tamamen doldur
        slider.value = 1f;
    }


    private IEnumerator DüşmanEkip()
    {
        while (spawnEnemyCount < 100)
        {
            var wait = new WaitForSeconds(0.1f);
            yield return wait;
            spawnMonster.SpawnMonsterOnButtonPress();
            spawnEnemyCount++;
        }
    }


    private IEnumerator Start()
  {


    StartCoroutine(DüşmanEkip());

    WaitForSeconds wait = new WaitForSeconds(düşmanGelmeSüresi);
    yield return wait;

    StartCoroutine(DestekEkip());
  }

 

   
  
    private IEnumerator DestekEkip()
  {
    // 1dk sonra gelicekler

    while (spawnDostCount < 200)
    {
      var wait = new WaitForSeconds(0.1f);
      yield return wait;
      spawnUnit.SpawnUnitOnButtonPress();
      spawnDostCount++;
    }
  }
}