namespace Assembly_FSharp
open UnityEngine

type Bullet() =
    inherit MonoBehaviour()    

    member this.Start() =
        let startupMessage = "Printed on start"
        Debug.Log(startupMessage)
        
    member this.Update() =
        let startupMessage = "Printed on every update"
        ()

