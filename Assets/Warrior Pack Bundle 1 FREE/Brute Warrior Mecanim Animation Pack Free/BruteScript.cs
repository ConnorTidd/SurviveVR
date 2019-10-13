using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteScript : MonoBehaviour {

    public bool debug;
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    public Vector3 Drag;
    public float distanceBeforePunch;
    public float viewRadius;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private NavMeshAgent _agent;

    public Transform player;
    static Animator anim;

    Vector3 smoothDeltaPosition = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    int i;
    private bool AttackTrigger;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(2);
        _agent = GetComponent<NavMeshAgent>();
        _agent.updatePosition = false;
        i = 0; // for debugging
    }

    // Update is called once per frame
    void Update()
    {
        // only occurs once
        if (Vector3.Distance(player.position, this.transform.position) < viewRadius && _agent.destination == _agent.nextPosition)
        {
            _agent.destination = player.position;
        }
        if(_agent.isStopped == true && Vector3.Distance(player.position, transform.position) - 10 > distanceBeforePunch)
        {
            Debug.Log("resuming");
           _agent.isStopped = false;
            AttackTrigger = false;
        }

        Vector3 worldDeltaPosition = _agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dz = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector3 deltaPosition = new Vector3(dx, 0, dz);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector3.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;
        
 
        bool shouldMove = !_agent.isStopped;

        if (debug)
        {
            i++;
            Debug.Log("Agent remaining Distance: " + _agent.remainingDistance + " Distance before punch: " + distanceBeforePunch);

            /*
            Debug.DrawRay(transform.position, velocity, Color.red);
            Debug.DrawLine(transform.position, new Vector3(distanceBeforePunch, distanceBeforePunch));
            if (i % 100 == 0)
            {
                Debug.Log("shouldMove: " + shouldMove + " Velocity: " + velocity);
                Debug.Log("agent next position" + _agent.nextPosition);
                Debug.Log("smooth delta position" + smoothDeltaPosition);
            }
            */
        }


        anim.SetBool("Moving", shouldMove);

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        // gravity always acts

        _velocity.y += Gravity * Time.deltaTime;

        // _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        // _velocity.z /= 1 + Drag.z * Time.deltaTime;
        if(shouldMove)
        {
            transform.position = _agent.nextPosition;
        }

        if (Vector3.Distance(player.position, this.transform.position) < viewRadius && Vector3.Distance(player.position, transform.position) - 4 < distanceBeforePunch && _agent.isStopped == false)
        {
            Debug.Log("Stopping");
            _agent.isStopped = true;
            AttackTrigger = true;
        }

        if(AttackTrigger)
        {
            Attack();
        }
        /*
        // Adjustable view range
        if(Vector3.Distance(player.position, this.transform.position) < viewRadius && Vector3.Distance(player.position, this.transform.position) > distanceBeforePunch)
        {

            Debug.DrawRay(this.transform.position, direction);
            anim.SetBool("Moving", true);
            Vector3 move = new Vector3(direction.x, 0, direction.z);
            _controller.Move(move * Time.deltaTime * Speed);

            if (move != Vector3.zero)
                transform.forward = move;
        }
        else if(Vector3.Distance(player.position, this.transform.position) < viewRadius && Vector3.Distance(player.position, this.transform.position) < distanceBeforePunch)
        {
            Debug.DrawRay(this.transform.position, direction);
            Attack();
        }
        */
        //  _controller.Move(_velocity * Time.deltaTime);

    }

    private void Attack()
    {
        anim.SetTrigger("Attack1Trigger");
    }
    private void Jump()
    {
        _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

    private void Dash()
    {
        _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
    }
    private void FootL()
    {

    }

    private void FootR()
    {

    }

    private void Hit()
    {
        Debug.Log("hit just occured");
    }
}
