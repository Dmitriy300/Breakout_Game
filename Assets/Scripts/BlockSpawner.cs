using System;
using TMPro;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Префаб блока
    public TextMeshProUGUI blockCountText;
    public int rows = 5; // Количество рядов блоков
    public int columns = 10; // Количество столбцов блоков
    public float spacing = 0.5f; // Промежуток между блоками

    // Задайте границы для игрового поля
    public float width = 8f; // Ширина области спавна
    public float height = 4f; // Высота области спавна

    //private int totalBlocks; // Общее количество блоков
   

    private void Start()
    {
        SpawnBlocks();
    }

    public void SpawnBlocks()
    {
        // находим начальную позицию для спавна
        float startX = -width / 2 + (blockPrefab.transform.localScale.x / 2);
        float startY = height / 2 - (blockPrefab.transform.localScale.y / 2);  // Начинаем спавн блоков с верхнего края

        // Количество спавненых блоков
        int totalBlocks = 0;

        // Цикл для создания блочных объектов в заданной области
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 blockPosition = new Vector3(startX + col * (blockPrefab.transform.localScale.x + spacing),
                                                     startY - row * (blockPrefab.transform.localScale.y + spacing),
                                                     0);
                Instantiate(blockPrefab, blockPosition, Quaternion.identity);
                totalBlocks++;
            }
        }

        // Устанавливаем количество блоков в ManagerGame
        ManagerGame.Instance.SetBrickCount(totalBlocks);

        // Обновляем текстовое поле для отображения количества блоков
        UpdateBlockCountText(totalBlocks);
             
    }

    private void UpdateBlockCountText(int count)
    {
        if (blockCountText != null)
        {
            blockCountText.text = "Block :" + count.ToString(); // Обновляем текст
        }
        else
        {
            Debug.LogError("blockCountText не назначен в инспекторе.");
        }

    }


}
