namespace Assembly_FSharp
open UnityEngine
open UnityEngine.SceneManagement

type Planet() =
    inherit MonoBehaviour()
        
    member this.handleEnemyDied (sound:AudioSource) = Handler<unit>(fun _ e ->
        sound.Play()
        let enemies = GameObject.FindGameObjectsWithTag("Enemy")
        Debug.Log enemies.Length
        if enemies.Length = 1 then
            SceneManager.LoadScene("Done"))
        
    member this.Start() =
        let explosionSound = this.GetComponent<AudioSource>()
        Enemy.EnemyDied.AddHandler (this.handleEnemyDied explosionSound)
        
        
    member this.Update() =
        ()
