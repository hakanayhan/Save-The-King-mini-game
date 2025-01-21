using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCamera : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask waterLayer;
    Camera cam;
    public Material material;

    RenderTexture rt;

    void Awake()
    {
        cam = GetComponent<Camera>();

        mainCamera = transform.parent.GetComponent<Camera>();
        cam.orthographicSize = mainCamera.orthographicSize;

        cam.cullingMask = waterLayer;
        int oldmask = mainCamera.cullingMask;

        int newmask = oldmask & ~(waterLayer);
        mainCamera.cullingMask = newmask;

        int resW = Screen.width;
        int resH = Screen.height;

        RenderTexture rt = new RenderTexture(resW, resH, 24);

        rt.name = "Water RT";
        cam.targetTexture = rt;
        material.SetTexture("_MainTex", rt);


    }

    private void Start()
    {
        CreateWaterQuad();
    }

    void CreateWaterQuad()
    {
        GameObject w = GameObject.CreatePrimitive(PrimitiveType.Quad);
        w.transform.position = cam.transform.position + cam.transform.forward * 0.35f;
        w.transform.rotation = Quaternion.LookRotation(w.transform.position - cam.transform.position);
        w.transform.SetParent(mainCamera.transform);

        float aspect = (float)Screen.width / (float)Screen.height;
        float width = cam.orthographicSize * 2 * aspect;
        float height = cam.orthographicSize * 2;

        w.transform.localScale = new Vector3(width, height, 1);

        w.GetComponent<Renderer>().material = material;
    }
}
