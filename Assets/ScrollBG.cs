using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

    public float mParalax = 1;

	void Start () {
	
	}
	
	void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / mParalax;
        offset.y = transform.position.y / mParalax;
        mat.mainTextureOffset = offset;
	}

}
