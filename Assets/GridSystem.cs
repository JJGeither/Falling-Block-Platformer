using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    //Variables
    private int[,] _gridDimensions;
    public int _xSize, _ySize;
    public int _blockSize;

    // Start is called before the first frame update
    void Start()
    {
        _gridDimensions = new int[_xSize, _ySize];

        for (int i = 0; i < _xSize; i++)
        {
            for (int j = 0; j < _ySize; j++)
            {
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
