using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathControler : MonoBehaviour
{

    public UnityEngine.UI.Text waveInformer;
    public GameObject deathScreen;
    public GameObject winScreen;
    public GameObject[] enemys;
    public Transform targetForEnemySpawn;
    public float spawnZoneX;
    public float spawnZoneY;
    public float spawnZoneZ;

    //public variables for other scripts
    public int enemyCountDetailsInScript;
    public int waveCountDetailsInScript;

    GameObject[] canvases;

    private void Start()
    {
        //Counting enemys in scene
        GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountDetailsInScript= GameObject.FindGameObjectsWithTag("Enemy").Length;
    }



    public void DeathEavent(string tag)
    {
        //resolwing what to doo with tag
        switch (tag)
        {
            case "Player":
                {
                    //Death sequence for player   
                    canvases = GameObject.FindGameObjectsWithTag("UI");
                    for (int i = 0; i < canvases.Length; i++)
                        canvases[i].SetActive(false);
                    deathScreen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                }
            case "Enemy":
                {
                    enemyCountDetailsInScript--;
                    break;
                }
            default:
                {
                    break;
                }
        }

        //Wave Controler
        if (enemyCountDetailsInScript <= 0)
        {
            waveCountDetailsInScript++;
            if (waveCountDetailsInScript > 3)
            {
                //Win sequence
                canvases = GameObject.FindGameObjectsWithTag("UI");
                for (int i = 0; i < canvases.Length; i++)
                    canvases[i].SetActive(false);
                winScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
            }
            else
            {
                NextWave(waveCountDetailsInScript);
            }
        }

    }

    public void NextWave(int wave)
    {
        waveInformer.GetComponentInChildren<CountDown>().time = 5f;
        waveInformer.gameObject.SetActive(true);

        Invoke("SpawnEnemy", 5f);
    }

    //render gizmo to imagine spawn box
    /*private void OnDrawGizmosSelected()
     {
         Gizmos.DrawCube(target.position, new Vector3(spawnZoneX, spawnZoneY, spawnZoneZ));
     }*/

    public void SpawnEnemy()
    {
        Vector3 randomVec;
        NavMeshHit destination;
        GameObject enemy;
        for (int i = 0; i < enemys.Length; i++)
            for (int j = 0; j < waveCountDetailsInScript; j++)
            {

                randomVec = new Vector3(Random.value * spawnZoneX - spawnZoneX / 2, Random.value * spawnZoneY - spawnZoneY / 2, Random.value * spawnZoneZ - spawnZoneZ / 2);
                //Calculating nearest point in NavMesh to randomly generated point
                if (NavMesh.SamplePosition(targetForEnemySpawn.position + randomVec, out destination, spawnZoneY, NavMesh.AllAreas))
                {
                    enemyCountDetailsInScript++;
                    enemy = Instantiate(enemys[i]);
                    enemy.transform.position = destination.position+Vector3.up*0.5f;

                    //search and destination
                    if (GameObject.FindGameObjectWithTag("Player"))
                    {
                        if (enemy.GetComponent<DynamicEnemyAI>())
                            enemy.GetComponent<DynamicEnemyAI>().target = GameObject.FindGameObjectWithTag("Player").transform;
                        if (enemy.GetComponent<StaticEnemyAI>())
                            enemy.GetComponent<StaticEnemyAI>().target = GameObject.FindGameObjectWithTag("Player").transform;
                    }
                }
            }
    }
}
