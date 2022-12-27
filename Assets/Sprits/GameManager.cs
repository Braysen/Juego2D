using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject Columna;
    public GameObject Piedra1;
    public GameObject Piedra2;
    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    public float velocidad = 2;

    void Start()
    {
        //Crear piso
        for(int i = 0; i < 20; i++)
        {
            cols.Add(Instantiate(Columna, new Vector2(-10+i,-3), Quaternion.identity));
        }
        obstaculos.Add(Instantiate(Piedra1, new Vector2(14,-1.75f), Quaternion.identity));
        obstaculos.Add(Instantiate(Piedra2, new Vector2(18,-1.75f), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.75f,0) * Time.deltaTime;

        //Llenar mapa
        for(int i = 0; i < cols.Count; i++)
        {
            if(cols[i].transform.position.x <= -10)
            {
                cols[i].transform.position = new Vector3(10,-3,0);
            }
            //cols[i].transform.position = cols[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
            cols[i].transform.position = cols[i].transform.position + new Vector3(0,0,0) * Time.deltaTime * velocidad;
        }

        //Llenar obstaculos
        for(int i = 0; i < obstaculos.Count; i++)
        {
            if(obstaculos[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(11,18);
                obstaculos[i].transform.position = new Vector3(randomObs,-1.75f,0);
            }
            obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
        }
    }
}
