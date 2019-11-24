﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarScript : MonoBehaviour
{
    public GameObject m_FogOfWarPlane;
    public Transform m_Player;
    public LayerMask m_fogLayer;
    public float m_radius = 5.0f;
    private  float  m_radiusSqr { get { return m_radius * m_radius; } }

    private Mesh m_mesh;
    private Vector3[] m_vertices;
    private Color[] m_colours;


    public float maxTime =10;
    public float timer;
    public GameObject Player;
    public Light lamp;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
     

        timer += Time.deltaTime ;
        if(timer> maxTime)
        {
            m_radius -= 0.5f;
            //lamp.intensity --;
            lamp.color -= (Color.white / 7.0f);
            timer = 0;
            
        }


       if(m_radius <= 3)
        {
            Player.SetActive(false);
        }

        Ray r = new Ray(transform.position, m_Player.position - transform.position);
        if (Physics.Raycast(r, out RaycastHit hit, 1000, m_fogLayer, QueryTriggerInteraction.Collide))
        {
            for (int i = 0; i < m_vertices.Length; i++)
            {
                Vector3 v = m_FogOfWarPlane.transform.TransformPoint(m_vertices[i]);
                float dist = Vector3.SqrMagnitude(v - hit.point);

                if (dist < m_radiusSqr)
                {
                    float alpha = Mathf.Min(m_colours[i].a, dist / m_radiusSqr);
                    m_colours[i].a = alpha;
                }

                else
                {
                    m_colours[i].a = 1;
                }
            }

            UpdateColour();
        }
    }

    void Init()
    {
        m_mesh = m_FogOfWarPlane.GetComponent<MeshFilter>().mesh;
        m_vertices = m_mesh.vertices;
        m_colours = new Color[m_vertices.Length];

        for(int i=0; i< m_colours.Length; i++)
        {
            m_colours[i] = Color.black;

        }

        UpdateColour();
    }


   void UpdateColour()
    {
        m_mesh.colors = m_colours;

    }

}
