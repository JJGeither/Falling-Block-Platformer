using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    //Variables
    public int _blockType;
    private Rigidbody2D _rigidBody;

    private SpriteRenderer _spriteRenderer;
    private Sprite[] _sprites;

    public Collision _colission;

    public GameObject _blockHandler;
    public BlockHandler _blockHandlerScript;

    public GameObject[] _blockObjectArray;

    public bool _placed;

    public Vector2[] tilePositions;    //the center of eac of the tiles that make up the block

    private void Start()
    {
        _sprites = Resources.LoadAll<Sprite>("Sprite/TetrisPieces");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();

        _rigidBody = GetComponent<Rigidbody2D>();
        _placed = false;
        _blockHandler = GameObject.Find("BlockHandlerObj");
        _blockHandlerScript = _blockHandler.GetComponent <BlockHandler>();

        transform.localScale = new Vector2(100,100);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(_placed == false)
        {
            _blockHandlerScript.SpawnBlock();
            Debug.Log("Hit");
            _rigidBody.velocity = new Vector2(0,0);
            _rigidBody.isKinematic = true;
            _rigidBody.gravityScale = 0;
            SnapToGrid();
            _placed = true;
            
        }
    }

    public void SnapToGrid()
    {
        Vector3 tmp = transform.position;
        tmp.y = Mathf.Round(transform.position.y);
        transform.position = tmp;
    }

    public void SetSprite()
    {
        
        switch(_blockType)
        {
            case 0: //I
                _spriteRenderer.sprite = _sprites[0];
                return;

            case 1: //L
                _spriteRenderer.sprite = _sprites[1];
                return;

            case 2: //L2
                _spriteRenderer.sprite = _sprites[2];
                return;

            case 3: //S
                _spriteRenderer.sprite = _sprites[3];
                return;

            case 4: //Square
                _spriteRenderer.sprite = _sprites[4];
                return;

            case 5: //T
                _spriteRenderer.sprite = _sprites[5];
                return;

            case 6: //Z
                _spriteRenderer.sprite = _sprites[6];
                return;


        }
    }

}
