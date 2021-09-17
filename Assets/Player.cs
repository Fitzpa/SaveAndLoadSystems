using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Rigidbody _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal, 0, vertical).normalized;
        _rigidbody.velocity = velocity * _speed;
    }

    void OnDisable()
    {
        var json = JsonUtility.ToJson(transform.position);
        PlayerPrefs.SetString("PlayerPosition", json);
        
        // PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        // PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        // PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
    }
    
    void OnEnable()
    {
        if (PlayerPrefs.HasKey("PlayerPosition"))
        {
            var json = PlayerPrefs.GetString("PlayerPosition");
            transform.position = JsonUtility.FromJson<Vector3>(json);
        }
        // if (PlayerPrefs.HasKey("PlayerX"))
        // {
        //      var x = PlayerPrefs.GetFloat("PlayerX");
        //      var y = PlayerPrefs.GetFloat("PlayerY");
        //      var z = PlayerPrefs.GetFloat("PlayerZ");
        //     transform.position = new Vector3(x, y, z);
        // }
    }
}
