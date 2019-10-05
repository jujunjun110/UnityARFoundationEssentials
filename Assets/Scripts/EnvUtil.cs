using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvUtil : MonoBehaviour {
    [SerializeField] Camera productionCamera;
    [SerializeField] Camera debugCamera;

    void Start() {
        Debug.LogFormat("IS EDITOR?: {0}", Application.isEditor);

        if (Application.isEditor) {
            productionCamera.gameObject.SetActive(false);
            debugCamera.gameObject.SetActive(true);
        } else {
            productionCamera.gameObject.SetActive(true);
            debugCamera.gameObject.SetActive(false);
        }
    }
}
