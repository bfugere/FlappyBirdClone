using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Cached References
    private Rigidbody2D birdRigidBody2D;
    private State state;

    private static Bird instance;

    public static Bird GetInstance()
    {
        return instance;
    }

    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;

    private float jumpAmount = 80f;

    private enum State
    {
        WaitingToStart,
        Playing,
        Dead
    }

    void Awake()
    {
        instance = this;
        birdRigidBody2D = GetComponent<Rigidbody2D>();
        birdRigidBody2D.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
    }

    void Update()
    {
        switch (state)
        {
            default:

            case State.WaitingToStart:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    birdRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    if (OnStartedPlaying != null)
                        OnStartedPlaying(this, EventArgs.Empty);
                }
                break;

            case State.Playing:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    Jump();

                transform.eulerAngles = new Vector3(0, 0, birdRigidBody2D.velocity.y * .15f);
                break;

            case State.Dead:
                break;
        }
    }

    void Jump()
    {
        birdRigidBody2D.velocity = Vector2.up * jumpAmount;
        SoundManager.PlaySound(SoundManager.Sound.BirdJump);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        birdRigidBody2D.bodyType = RigidbodyType2D.Static;
        SoundManager.PlaySound(SoundManager.Sound.Lose);
        if (OnDied != null)
            OnDied(this, EventArgs.Empty);
    }
}
