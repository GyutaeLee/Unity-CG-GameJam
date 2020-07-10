﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 현재 테스트 용도로, 월드에 필요한 오브젝트들을 세팅한다.
 */
public class WorldSetter : MonoBehaviour
{
    Light[] m_cubeLights = new Light[6];
    Transform m_cubeWorldTransform;
    GameObject m_cubeWorldGameObject;

    enum PlaneDirectionEnum : uint
    {
        IN = 0,
        OUT = 1
    }


    enum WorldAreaEnum : uint
    {
        XPLUS = 0,
        XMINUS = 2,
        YPLUS = 4,
        YMINUS = 6,
        ZPLUS = 8,
        ZMINUS = 10
    }
    Vector3[] m_planeRelativePos = new Vector3[12];
    Quaternion[] m_planeRot = new Quaternion[12];
    GameObject[] m_prefabPlaneArea = new GameObject[12];
    Color[] m_planeColor = new Color[12];
     
    // Start is called before the first frame update
    void Start()
    {
        m_cubeWorldTransform = transform.Find("CubeWorld");
        m_cubeWorldGameObject = m_cubeWorldTransform.gameObject;

        // plane pos and rot init for debugging
        const float posMove = 1f;
        const float planeAlphaValue = 0.3f;
        m_planeRelativePos[(uint)WorldAreaEnum.XPLUS] = new Vector3(posMove, 0f, 0f);
        m_planeRot[(uint)WorldAreaEnum.XPLUS + (uint)PlaneDirectionEnum.IN] = Quaternion.Euler(0f, 0f, 90f);
        m_planeColor[(uint)WorldAreaEnum.XPLUS + (uint)PlaneDirectionEnum.IN] = new Color(1f, 0f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.XPLUS + 1] = new Vector3(posMove, 0f, 0f);
        m_planeRot[(uint)WorldAreaEnum.XPLUS + (uint)PlaneDirectionEnum.OUT] = Quaternion.Euler(0f, 0f, -90f);
        m_planeColor[(uint)WorldAreaEnum.XPLUS + (uint)PlaneDirectionEnum.OUT] = new Color(1f, 0f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.XMINUS] = new Vector3(-posMove, 0f, 0f);
        m_planeRot[(uint)WorldAreaEnum.XMINUS + (uint)PlaneDirectionEnum.IN] = Quaternion.Euler(0f, 0f, -90f);
        m_planeColor[(uint)WorldAreaEnum.XMINUS + (uint)PlaneDirectionEnum.IN] = new Color(1f, 0f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.XMINUS + 1] = new Vector3(-posMove, 0f, 0f);
        m_planeRot[(uint)WorldAreaEnum.XMINUS + (uint)PlaneDirectionEnum.OUT] = Quaternion.Euler(0f, 0f, 90f);
        m_planeColor[(uint)WorldAreaEnum.XMINUS + (uint)PlaneDirectionEnum.OUT] = new Color(1f, 0f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.YPLUS] = new Vector3(0f, posMove, 0f);
        m_planeRot[(uint)WorldAreaEnum.YPLUS + (uint)PlaneDirectionEnum.IN] = Quaternion.Euler(0f, 0f, 180f);
        m_planeColor[(uint)WorldAreaEnum.YPLUS + (uint)PlaneDirectionEnum.IN] = new Color(0f, 1f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.YPLUS + 1] = new Vector3(0f, posMove, 0f);
        m_planeRot[(uint)WorldAreaEnum.YPLUS + (uint)PlaneDirectionEnum.OUT] = Quaternion.Euler(0f, 0f, 0f);
        m_planeColor[(uint)WorldAreaEnum.YPLUS + (uint)PlaneDirectionEnum.OUT] = new Color(0f, 1f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.YMINUS] = new Vector3(0f, -posMove, 0f);
        m_planeRot[(uint)WorldAreaEnum.YMINUS + (uint)PlaneDirectionEnum.IN] = Quaternion.Euler(0f, 0f, 0f);
        m_planeColor[(uint)WorldAreaEnum.YMINUS + (uint)PlaneDirectionEnum.IN] = new Color(0f, 1f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.YMINUS + 1] = new Vector3(0f, -posMove, 0f);
        m_planeRot[(uint)WorldAreaEnum.YMINUS + (uint)PlaneDirectionEnum.OUT] = Quaternion.Euler(0f, 0f, 180f);
        m_planeColor[(uint)WorldAreaEnum.YMINUS + (uint)PlaneDirectionEnum.OUT] = new Color(0f, 1f, 0f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.ZPLUS] = new Vector3(0f, 0f, posMove);
        m_planeRot[(uint)WorldAreaEnum.ZPLUS + (uint)PlaneDirectionEnum.IN] = Quaternion.Euler(90f, 0f, 0f);
        m_planeColor[(uint)WorldAreaEnum.ZPLUS + (uint)PlaneDirectionEnum.IN] = new Color(0f, 0f, 1f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.ZPLUS + 1] = new Vector3(0f, 0f, posMove);
        m_planeRot[(uint)WorldAreaEnum.ZPLUS + (uint)PlaneDirectionEnum.OUT] = Quaternion.Euler(-90f, 0f, 0f);
        m_planeColor[(uint)WorldAreaEnum.ZPLUS + (uint)PlaneDirectionEnum.OUT] = new Color(0f, 0f, 1f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.ZMINUS] = new Vector3(0f, 0, -posMove);
        m_planeRot[(uint)WorldAreaEnum.ZMINUS + (uint)PlaneDirectionEnum.IN] = Quaternion.Euler(-90f, 0f, 0f);
        m_planeColor[(uint)WorldAreaEnum.ZMINUS + (uint)PlaneDirectionEnum.IN] = new Color(0f, 0f, 1f, planeAlphaValue);

        m_planeRelativePos[(uint)WorldAreaEnum.ZMINUS + 1] = new Vector3(0f, 0f, -posMove);
        m_planeRot[(uint)WorldAreaEnum.ZMINUS + (uint)PlaneDirectionEnum.OUT] = Quaternion.Euler(90f, 0f, 0f);
        m_planeColor[(uint)WorldAreaEnum.ZMINUS + (uint)PlaneDirectionEnum.OUT] = new Color(0f, 0f, 1f, planeAlphaValue);

        Material planeMat = Resources.Load("Prefab/PlaneTransparency") as Material;
        GameObject prefab = Resources.Load("Prefab/pAreaPlane") as GameObject;
        for (int i = 0; i < 12; ++i)
        {
            m_prefabPlaneArea[i] = GameObject.Instantiate(prefab, m_cubeWorldTransform);


            // Basic Setting
            WorldAreaEnum ew = ((i % 2) == 0 ? (WorldAreaEnum)i: (WorldAreaEnum)(i - 1));
            PlaneDirectionEnum ep = (PlaneDirectionEnum)(i % 2);
            m_prefabPlaneArea[i].name = ew.ToString() + '_' + ep.ToString();
            m_prefabPlaneArea[i].transform.localPosition = m_planeRelativePos[i];
            m_prefabPlaneArea[i].transform.localRotation = m_planeRot[i];

            // Material Setting
            MeshRenderer mr = m_prefabPlaneArea[i].GetComponent<MeshRenderer>();
            mr.material = Material.Instantiate(planeMat);
            mr.material.SetColor("_Color", m_planeColor[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}