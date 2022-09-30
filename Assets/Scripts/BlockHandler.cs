using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    //Variables
    public Vector2 _spawnPosition;
    public GameObject _blockObject;
    public float _timerSpawnLength;
    private float _timerAmount;

    public GameObject[] _blockObjectArray;

    public float _gravtiy;
    public int _blockSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, - _gravtiy);
        _blockObjectArray = Resources.LoadAll<GameObject>("BlockFolder");
        SetTimer(-1f);
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void SetTimer()
    {
        _timerAmount = _timerSpawnLength;
    }

    public void SetTimer(float value)   //sets timer with custom amount of time
    {
        _timerAmount = value;
    }

    public void UpdateTimer()
    {
        if (_timerAmount != -1)
        {
            _timerAmount -= Time.deltaTime;

            if (_timerAmount <= 0.0f)
            {
                TimerEnd();
                return;
            }
        }

    }
    public void TimerEnd()
    {
        Debug.Log("Timer End");
        SpawnBlock();
    }

    public void SpawnBlock()
    {

        GameObject block = Instantiate(_blockObject);
        int blockType = DetermineBlockType(ref block);
        block.GetComponent<BlockMovement>()._blockType = blockType;
        block.AddComponent<PolygonCollider2D>().points = _blockObjectArray[blockType].GetComponent<PolygonCollider2D>().points;
        block.transform.position = _spawnPosition;
        block.transform.parent = gameObject.transform;
    }

    public int DetermineBlockType(ref GameObject block)
    {
        switch(Random.Range(0,6))  //each number represents a piece type
        {
            case 0:
                block.name = "I-Piece " + block.GetInstanceID();
                return 0;

            case 1:
                block.name = "L2-Piece " + block.GetInstanceID();
                return 1;

            case 2:
                block.name = "L1-Piece " + block.GetInstanceID();
                return 2;

            case 3:
                block.name = "S-Piece " + block.GetInstanceID();
                return 3;

            case 4:
                block.name = "Square-Piece " + block.GetInstanceID();
                return 4;

            case 5:
                block.name = "T-Piece " + block.GetInstanceID();
                return 5;

            case 6:
                block.name = "Z-Piece " + block.GetInstanceID();
                return 6;

            default:
                return 0;
        }
    }
 

}
