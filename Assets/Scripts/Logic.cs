using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class Logic : MonoBehaviour {

	public int enemiesPerLine = 25;
	public int lines = 1;
	public float lineSeparation = 0.4f;
	public Transform enemyPrefab;
	public Enemy[] enemies;
	public Transform spawnA;
	public Transform spawnB;

	// Use this for initialization
	void Start ()
	{
	    enemies = new Enemy[enemiesPerLine * lines];
	    SpawnEnemies();
	    StartCoroutine(Respawn());
	}

    private IEnumerator Respawn()
    {
        const float secsWait = 3;

        while (true)
        {
            yield return new WaitForSeconds(secsWait);

            foreach (Enemy t in enemies.Where(t => !t.gameObject.activeSelf))
            {
                Debug.Log("Reactivating an enemy");
                t.gameObject.SetActive(true);
                break;
            }
        }
    }

    private void SpawnEnemies()
    {
        var enemyIndex = 0;
        //Debug.Log("Lines: " + lines + " ;EPL: " + enemiesPerLine);

        // Spawn some bad guys
        for (int j = 0; j < lines; j++)
        {
            for (int i = 0; i < enemiesPerLine; i++)
            {
                Vector3 newSpawnPos = Vector3.Lerp(spawnA.position, spawnB.position, i*(1f/enemiesPerLine));
                newSpawnPos.x -= lineSeparation*j;
                var newEnemy = Instantiate(Resources.Load("Enemy"), newSpawnPos, Quaternion.identity);
                enemies[enemyIndex++] = ((GameObject) newEnemy).GetComponent<Enemy>();
                //Debug.Log("Added enemy " + enemyIndex);
            }
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}
