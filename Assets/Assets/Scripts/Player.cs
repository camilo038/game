using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{ // Start is called before the first frame update
    //get handel(referencia)
    private Rigidbody2D _rigid;
    //variavle jump
    //varibale  bolena  = false
    private int _contador = 1;

    [SerializeField]
    private float _speed = 0.5f;
    //[SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private LayerMask _groundPlayer;

    private bool _resetJum = false;

    private PlayerAnimation _anim;

    //variable de animacion





    void Start()
    {

        //asign handle  of rigibody
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del jugador
        Movement();
        



        //Asignar vector  = new Velocity(x, current velocity.y);


    }

    void Movement() {

        float move = Input.GetAxisRaw("Horizontal");




   


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounde() == true)
        {


            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRutine());

        }

        //if  space  key &&  grannded = true

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _anim.Move(move);

        // _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);






    }


    bool IsGrounde()
    {

        RaycastHit2D histInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);

        if (histInfo.collider != null)
        {
                if (_resetJum == false)
            
                return true;
        }
        return false;
       

    }


    void CheckGround() {


        //if Jump   grannded  = fasle
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, _groundPlayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.2f, Color.green);
        {
            Debug.Log("HIt" + hitInfo.collider.name);
            
                _grounded = true;
            //breath

        }
    }


    IEnumerator ResetJumpRutine() {

        _resetJum = true;
        yield return new WaitForSeconds(0.3f);
        _resetJum = false;

    }

    
}
