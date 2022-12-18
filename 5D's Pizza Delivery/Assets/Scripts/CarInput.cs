using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput : MonoBehaviour
{
    CarAIController carAIController;

    // Update is called once per frame
    void Awake()
    {
        carAIController = GetComponent<CarAIController>();
    }
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        carAIController.SetInputVector(inputVector);
    }
}
