using System;
using TMPro;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // ������ �����
    public TextMeshProUGUI blockCountText;
    public int rows = 5; // ���������� ����� ������
    public int columns = 10; // ���������� �������� ������
    public float spacing = 0.5f; // ���������� ����� �������

    // ������� ������� ��� �������� ����
    public float width = 8f; // ������ ������� ������
    public float height = 4f; // ������ ������� ������

    //private int totalBlocks; // ����� ���������� ������
   

    private void Start()
    {
        SpawnBlocks();
    }

    public void SpawnBlocks()
    {
        // ������� ��������� ������� ��� ������
        float startX = -width / 2 + (blockPrefab.transform.localScale.x / 2);
        float startY = height / 2 - (blockPrefab.transform.localScale.y / 2);  // �������� ����� ������ � �������� ����

        // ���������� ��������� ������
        int totalBlocks = 0;

        // ���� ��� �������� ������� �������� � �������� �������
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

        // ������������� ���������� ������ � ManagerGame
        ManagerGame.Instance.SetBrickCount(totalBlocks);

        // ��������� ��������� ���� ��� ����������� ���������� ������
        UpdateBlockCountText(totalBlocks);
             
    }

    private void UpdateBlockCountText(int count)
    {
        if (blockCountText != null)
        {
            blockCountText.text = "Block :" + count.ToString(); // ��������� �����
        }
        else
        {
            Debug.LogError("blockCountText �� �������� � ����������.");
        }

    }


}
