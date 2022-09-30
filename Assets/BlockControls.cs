using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControls : MonoBehaviour
{
    //controls
    public KeyCode _Up, _Down, _Left, _Right;
    float _angle;
    bool _horizontalMovement;
    public LayerMask _layerMask;

    public BlockMovement _blockHandlerScript;
    public PolygonCollider2D _poly;

    // Start is called before the first frame update
    void Start()
    {
        _blockHandlerScript = this.GetComponent<BlockMovement>();
        _poly = this.GetComponent<PolygonCollider2D>();
        _angle = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_blockHandlerScript._placed)
        {
            //horizontal movement
            if (Input.GetKeyDown(_Left))
            {
                MoveHorizontally(-1);
            }

            if (Input.GetKeyDown(_Right))
            {
                MoveHorizontally(1);
            }

            //Rotational movement
            if (Input.GetKeyDown(_Up))
            {
                Rotate(-1);
            }

            if (Input.GetKeyDown(_Down))
            {
                Rotate(1);
            }
        }


        
    }

    void MoveHorizontally(int direction)
    {
        transform.position = new Vector2(transform.position.x + (direction), transform.position.y);

    }

    void Rotate(int rotation)
    {
        _angle += rotation * 90;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
