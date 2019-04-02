namespace Assembly_FSharp
open UnityEngine
open UnityEngine.SceneManagement

type MainMenu() =
    inherit MonoBehaviour()    

    member this.Start() =
        ()
        
    member this.Update() =
        ()
        
    member this.Restart() =
        SceneManager.LoadScene("Game")

