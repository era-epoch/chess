using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    public GameObject whiteTilePrefab;
    public GameObject blackTilePrefab;
    public GameObject container;

    public int rows;
    public int cols;


    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        Debug.Log(container.transform.position);
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 position = new Vector3(i, j);
                Vector3 adjPosition = position + container.transform.position;
                //Debug.Log(adjPosition);

                if (counter%2 == 0)
                {
                    GameObject tile = Instantiate(whiteTilePrefab, adjPosition, Quaternion.identity);
                    //Debug.Log(tile.transform.position);
                }
                else
                {
                    GameObject tile = Instantiate(blackTilePrefab, adjPosition, Quaternion.identity);
                    //Debug.Log(tile.transform.position);
                }
                counter += 1;
            }
            counter += 1;
        }
    }


}
