using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;
    public float speed = 5.0f;
    private Animator _animator;
    private bool isWalking = false;
    private bool isAttacking = false;
    public bool isTalking;
    public Vector2 lastMove = Vector2.zero;
    private Rigidbody2D _rb2d;
    public string nextUUID;
    
    public float attackTime;
    private float attackTimeCounter;
    //private const string H_AXIS = "Horizontal", V_AXIS = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        playerCreated = true; //Decimos al Dont Destroy que el jugador ha sido creado
        isTalking = false;
    }

    // Update is called once per frame
    void Update(){
        if(isTalking){
             _rb2d.velocity = Vector2.zero;
             _animator.SetBool(Utils.WALK, false);
             _animator.SetBool(Utils.ATT, false);
            return;
        }
         isWalking = false; 
        if(isAttacking){
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter<0){
                isAttacking = false;
                _animator.SetBool(Utils.ATT, false);
            }
        }else if(Input.GetMouseButtonDown(0)){
            isAttacking = true;
            attackTimeCounter = attackTime; //Mismo funcionamiento que en EnemyController
            _rb2d.velocity = Vector2.zero;
            _animator.SetBool(Utils.ATT, true);
        }


        if(Mathf.Abs(Input.GetAxisRaw(Utils.H_AXIS))>0.2f){
            _rb2d.velocity = Vector2.zero;
            //Vector3 move = new Vector3(Input.GetAxisRaw(Utils.H_AXIS)*speed*Time.deltaTime,0,0);
            //this.transform.Translate(move);
           // if(Input.GetButtonUp(Utils.H_AXIS)){
           //     _rb2d.velocity = Vector2.zero;
           // }
            _rb2d.velocity = new Vector2(Input.GetAxisRaw(Utils.H_AXIS),_rb2d.velocity.y).normalized*speed;
            isWalking = true;
            lastMove = new Vector2(Input.GetAxisRaw(Utils.H_AXIS),0);

        }
        if(Mathf.Abs(Input.GetAxisRaw(Utils.V_AXIS))>0.2f){
            _rb2d.velocity = Vector2.zero;
            //Vector3 move = new Vector3(0,Input.GetAxisRaw(Utils.V_AXIS)*speed*Time.deltaTime,0);
            //this.transform.Translate(move);
          //  if(Input.GetButtonUp(Utils.V_AXIS)){
           //     rb2d.velocity = Vector2.zero;
           // }
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, Input.GetAxisRaw(Utils.V_AXIS)).normalized*speed;
            isWalking = true;
            lastMove = new Vector2(0,Input.GetAxisRaw(Utils.V_AXIS));

        }

    }
    private void LateUpdate() {
        if(!isWalking){
            _rb2d.velocity = Vector2.zero;
        }
        _animator.SetFloat(Utils.H_AXIS, Input.GetAxisRaw(Utils.H_AXIS));
        _animator.SetFloat(Utils.V_AXIS, Input.GetAxisRaw(Utils.V_AXIS));
        _animator.SetBool(Utils.WALK, isWalking);
        _animator.SetFloat(Utils.LH, lastMove.x);
        _animator.SetFloat(Utils.LV, lastMove.y);
    }
}
