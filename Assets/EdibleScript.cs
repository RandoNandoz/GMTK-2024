using System.Collections;
using System.Collections.Generic;
using Characters.Player;
using UnityEngine;

public class EdibleScript : MonoBehaviour
{
    [SerializeField] private float massGiven;
    private GameObject _player;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    private GekkoScript gekkoScript;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        gekkoScript = _player.GetComponent<GekkoScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gekkoScript.eat(massGiven);
            EatAction();
        }
    }

    /// <summary>
    /// Custom EatAction behaviour, user-overrideable for different edible objects.
    /// </summary>
    protected virtual void EatAction()
    {
        // do nothing
        Destroy(gameObject);
    }
}