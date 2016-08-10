using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / 10f;
        offset.y = transform.position.y / 10f;
        mat.mainTextureOffset = offset;
	}

}
