namespace Assembly_FSharp
open UnityEngine
open UnityEngine.SceneManagement

type Planet() =
    inherit MonoBehaviour()
    
    [<SerializeField>]
    let mutable enemies:GameObject = null
    

    member this.Start() =
        ()

    member this.Update() =
        if enemies.transform.childCount = 0 then
            SceneManager.LoadScene("Done")
