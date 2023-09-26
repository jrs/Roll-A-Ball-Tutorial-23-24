using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstaclePlayer : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public GameObject WinText;

    public float Speed = 10;
    public float GravityModifier = 1;
    private int _count;

    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _count = 0;
        Physics.gravity = Physics.gravity * GravityModifier;
        CountText.text = "Count: " + _count.ToString();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput;
        float verticalInput;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        _playerRigidbody.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            CountText.text = "Count: " + _count.ToString();

            if (_count >= 8)
            {
                WinText.gameObject.SetActive(true);
            }

        }
    }

}
