using UnityEngine;
using Wellz.Utils.Core;

public class GameManager : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        UtilsClass.CreateWorldText("Olá este é um teste", color: UtilsClass.GetRandomColor());
    }

    // Update is called once per frame
    void Update() {
    }
}
